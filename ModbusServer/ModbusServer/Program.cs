using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.IO.Ports;
using System.Threading;

namespace ModbusServer
{
    class Program
    {
        public static void CallToChildThread()
        {
            ModbusSerialSlave slv;
            SerialPort porta;
            byte m_addr;

            m_addr = 1;
            porta = new SerialPort();
            porta.PortName = "COM1";
            porta.DataBits = 8;
            porta.Parity = Parity.None;
            porta.StopBits = StopBits.One;
            porta.BaudRate = 19200;

            slv = ModbusSerialSlave.CreateRtu(m_addr, porta);

            try
            {
                porta.Open();
                slv.Listen();
            }
            catch (Exception)
            {
                porta.Close();
                throw;
            }
        }

        public static void CallToChildThread1()
        {
            ModbusSerialSlave slv;
            SerialPort porta;
            byte m_addr;

            m_addr = 1;
            porta = new SerialPort();
            porta.PortName = "COM2";
            porta.DataBits = 8;
            porta.Parity = Parity.None;
            porta.StopBits = StopBits.One;
            porta.BaudRate = 19200;

            slv = ModbusSerialSlave.CreateRtu(m_addr, porta);

            try
            {
                porta.Open();
                slv.Listen();
            }
            catch (Exception)
            {
                porta.Close();
                throw;
            }
        }

        static void Main(string[] args)
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Thread childThread = new Thread(childref);
            childThread.Start();

            ThreadStart childref1 = new ThreadStart(CallToChildThread1);
            Thread childThread1 = new Thread(childref1);
            childThread1.Start();

            Console.ReadKey();
            //for (; ; )
            //{
            //    try
            //    {
            //        childThread.Start();
            //    }
            //    catch (Exception)
            //    {
            //        childThread.Abort();
            //    }

            //    try
            //    {
            //        childThread1.Start();
            //    }
            //    catch (Exception)
            //    {
            //        childThread1.Abort();
            //    }
            //}
        }

        static byte AskPort()
        {
            byte ret = 0xFF;

            Console.Out.WriteLine("Escolha uma porta");

            foreach (String str in SerialPort.GetPortNames())
            {
                Console.Out.WriteLine(str);
            }

            ret = (byte)Console.In.Read();

            return ret;
        }
    }
}
