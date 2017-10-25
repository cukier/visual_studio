using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.IO.Ports;

namespace MestreModbus
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort passo = 50;

            SerialPort p = new SerialPort
            {
                PortName = "COM2",
                BaudRate = 19200,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                ReadTimeout = 200
            };

            ModbusSerialMaster m = ModbusSerialMaster.CreateRtu(p);

            try
            {
                ushort aux;

                aux = 0;
                p.Open();

                for (ushort cont = 0; cont < 150; ++cont)
                {                    
                    foreach (ushort reg in m.ReadHoldingRegisters(1, (ushort)(cont * passo), passo))
                    {
                        Console.Out.WriteLine(aux + " " + reg);
                        aux++;
                    }    

                    Console.WriteLine();
                }

                Console.Out.WriteLine("Leitura feita");
            }
            catch (Exception e)
            {
                Console.Out.Write(e.StackTrace);
                Console.Out.WriteLine("\nErro na leitura");
            }
            finally
            {
                p.Close();
                Console.Out.WriteLine("Porta fechada");
            }

            Console.In.ReadLine();
        }
    }
}
