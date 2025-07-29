# HL7-Tester
windows application to test hl7 connections and ports

# 🧩 Overview
This Windows Forms application is designed to send basic HL7 messages over a TCP/IP connection using the MLLP (Minimal Lower Layer Protocol) envelope. It includes configurable message batching, dynamic ACK handling, and basic input validation.
🎯 Key Features
- Configurable payload size (1, 20, 50, or 100 messages)
- Replaces message control ID dynamically per batch
- Displays sent messages and received ACKs in real time
- Validates IP address and port input
- Uses HL7 v2.3 SIU^S14 scheduling message structure
# 💬 Example Message Format
MSH|^~\&|APPT|MYCLINIC|TESTMESSAGECLINIC|TESTMESSAGECLINIC|...||SIU^S14|####|P|2.3|
SCH|...|UPDATE^Update|...
NTE|1|L|testing this interface
PID|1||9999|9999|...
PV1|1|ACTIVE|...
RGS|001
AIS|1||EST^Established Patient|...
AIL|1||XYZ^XYZ Clinic|...
AIP|1||ABC^Sample^Physician|...

# ⚙️ Usage
- Launch the application
- Enter the destination IP address and port
- Select the message batch size
- Click Send Payload
- Watch the outputListbox and ackListbox update in real-time
# 🧼 Input Validation
- IP address format checked with System.Net.IPAddress.TryParse
- Port validated as a number between 1–65535
# 🪵 Logging
- Each sent message is timestamped and listed in outputData
- ACKs are decoded and displayed in ackData
- Exceptions are logged per message or as a total failure on the first attempt
📦 Classes & Methods
| Name | Purpose | 
| Form1 | Main form logic | 
| MllpWrap(string) | Wraps HL7 message with VT/FS framing | 
| MessagePayloadSizes() | Returns selectable batch sizes | 
| ReadMllpMessageAsync | Async ACK reader with MLLP unframing logic | 


# ✅ Prerequisites
- .NET Framework (or .NET Core Windows Forms)
- Visual Studio for building/debugging

# 📌 Notes
- Messages use UTF-8 encoding
- Delay of 50 ms between sends to allow stream readiness
- Fully async TCP implementation with ACK logging per cycle
