using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cshl7test
{
    public partial class Form1 : Form
    {

        public List<string> outputData = new List<string>();
        public List<string> ackData = new List<string>();
        public int sendIndex = 0;

        public string testMessage = @"MSH|^~\&|APPT|XYZ_2842|ABC_HEALTH|ABC_PHS|20250724112943||SIU^S14|####|P|2.3|\r" +
@"SCH|1622887|1622887||||UPDATE^Update|EST^Established Patient|EST^Established office visit|20|min|^^^20250729104000^20250729110000|||||test^a^message||||test^a^message|^^^myemail@test.com\r" +
@"NTE|1|L|testing this interface\r" +
@"PID|1||9999|9999|test^tester||19450521|M||C|123 test way^^Bonita Springs^FL^34135^US||(999) 999-9999^PRN^PH^test@yahoo.com^^999^9999999~(999) 999-9999^ORN^CP^^^999^9999999~^NET^Internet^test@yahoo.com|^^^test@yahoo.com|ENG^English^L|M||289275|999999999|||X||||||||N\r" +
@"PV1|1|ACTIVE|||||LDS^Delgado^L~9999999999^Delgado^L^^^^^^CMS^^^^NPI|||||||||||||\r" +
@"RGS|001\r" +
@"AIS|1||EST^Established Patient|20250729104000|||20|min\r" +
@"AIL|1||PP02^^^^^^^^^XYZ Practice- Dr. Test|O||20250729104000|||20|min\r" +
@"AIP|1||TN^TEST^Name^^ARPN|PP02^XYZ Practice||20250729104000|||20|min\r";


    public    List<MessagePayloadSize> MessagePayloadSizes()
        {
            var lst = new List<MessagePayloadSize>();
            lst.Add(new MessagePayloadSize(1, "1 Message"));
            lst.Add(new MessagePayloadSize(20, "20 Messages"));
            lst.Add(new MessagePayloadSize(50, "50 Messages"));
            lst.Add(new MessagePayloadSize(100, "100 Messages"));
            return lst;
        }
    

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            payloadSizeSelector.DataSource = MessagePayloadSizes();
            payloadSizeSelector.DisplayMember = "Description";
            payloadSizeSelector.ValueMember = "Size";
            outputListbox.DataSource = outputData;
            ackListbox.DataSource = ackData;

        }

        public string MllpWrap(string message)
        {
            return "\x0B" + message + "\x1C" + "\r";
        }

        private async void sendPayload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ipAddressInput.Text))
            {
                MessageBox.Show("Please enter a valid IP address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sendPayload.Enabled = true;
                return;
            }

            // check if the ip is valid
            if (!System.Net.IPAddress.TryParse(ipAddressInput.Text, out _))
            {
                MessageBox.Show("Please enter a valid IP address format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sendPayload.Enabled = true;
                return;
            }

            // check for a valid port number
            if (!int.TryParse(portInput.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Please enter a valid port number (1-65535).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sendPayload.Enabled = true;
                return;
            }


            sendPayload.Enabled = false;
            sendPayload.Text = "Sending...";
            outputData.Clear();
            ackData.Clear();


            // Determine connection type and IP

            string ip = ipAddressInput.Text;

         
            int portNum = int.Parse(portInput.Text);

            // Get payload size
            var payloadSize = (MessagePayloadSize)payloadSizeSelector.SelectedItem;
            int messageCount = payloadSize.Size;

            // Prepare message template
            string messageTemplate = testMessage;

            try
            {
                using (var client = new System.Net.Sockets.TcpClient())
                {
                    await client.ConnectAsync(ip, portNum);
                    using (var stream = client.GetStream())
                    {
                        for (int i = 1; i <= messageCount; i++)
                        {
                            string message = messageTemplate.Replace("####", i.ToString());
                            string wrapped = MllpWrap(message);
                            byte[] data = Encoding.UTF8.GetBytes(wrapped);

                            try
                            {
                                await stream.WriteAsync(data, 0, data.Length);
                            }
                            catch (Exception ex)
                            {
                                if (i == 1)
                                {
                                    MessageBox.Show($"Failed to connect or send first message: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break; // Stop everything
                                }
                                else
                                {
                                    outputData.Add($"Error sending message {i}: {ex.Message}");
                                    outputListbox.DataSource = null;
                                    outputListbox.DataSource = outputData;
                                    break;
                                }
                            }

                            string log = $"{DateTime.Now:HH:mm:ss.fff} - Sent message {i}";
                            outputData.Add(log);
                            outputListbox.DataSource = null;
                            outputListbox.DataSource = outputData;

                            var ack = await ReadMllpMessageAsync(stream);
                            string ackLog = $"{DateTime.Now:HH:mm:ss.fff} - ACK {i}: {ack}";
                            ackData.Add(ackLog);
                            ackListbox.DataSource = null;
                            ackListbox.DataSource = ackData;

                            await Task.Delay(50);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                outputData.Add($"Error: {ex.Message}");
                outputListbox.DataSource = null;
                outputListbox.DataSource = outputData;
            }
            finally
            {
                sendPayload.Enabled = true;
                outputData.Add("Done");
                sendPayload.Text = "Send Payload";
            }
        }

        private async Task<string> ReadMllpMessageAsync(System.Net.Sockets.NetworkStream stream)
        {
            var buffer = new List<byte>();
            bool started = false;
            var readBuffer = new byte[1];

            while (true)
            {
                int bytesRead = await stream.ReadAsync(readBuffer, 0, 1);
                if (bytesRead == 0) break; // End of stream

                byte b = readBuffer[0];

                if (!started)
                {
                    if (b == 0x0B) // <VT>
                    {
                        started = true;
                    }
                    continue;
                }
                if (b == 0x1C) // <FS>
                {
                    // Optionally read the trailing \r
                    await stream.ReadAsync(readBuffer, 0, 1);
                    break;
                }
                buffer.Add(b);
            }
            return Encoding.UTF8.GetString(buffer.ToArray());
        }


        private void connectionInfo_Click(object sender, EventArgs e)
        {

        }
    }


}
