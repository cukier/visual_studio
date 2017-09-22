using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        public static void Main()
        {
            SerialPort mySerialPort = new SerialPort("COM5");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.Open();

            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
            mySerialPort.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.Write("Data Received:");
            Console.WriteLine(indata);
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadTimeout = 1000;
            serialPort.Open();

            serialPort.Write("AT");

            try
            {
                Console.Out.WriteLine(serialPort.ReadLine());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.StackTrace);
            }
            finally
            {
                serialPort.Close();
                serialPort.Dispose();
            }

            /*SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 19200;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadTimeout = 1000;
            serialPort.Open();
            ModbusSerialMaster master = ModbusSerialMaster.CreateRtu(serialPort);

            ushort[] data = master.ReadHoldingRegisters(1, 0, 100);

            foreach(ushort i in data)
            {
                Console.Out.WriteLine(i);
            }

            master.Dispose();
            serialPort.Close();
            Console.In.Read();
        }
    }
*/
}
