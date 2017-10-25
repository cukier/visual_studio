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
        static void Main(string[] args)
        {
            ModbusSerialSlave slv;
            SerialPort porta;

            porta = new SerialPort();
            porta.PortName = "COM1";
            porta.DataBits = 8;
            porta.Parity = Parity.None;
            porta.StopBits = StopBits.One;
            porta.BaudRate = 19200;

            try
            {
                porta.Open();
            }
            catch (Exception e)
            {
                porta.Close();
                Console.Out.WriteLine("erro porta");
                Console.Out.Write(e.ToString());
            }

            slv = ModbusSerialSlave.CreateRtu(1, porta);
        }
    }
}
