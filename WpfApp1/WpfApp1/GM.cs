using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.IO.Ports;

namespace WpfApp1
{
    class GM
    {
        private ModbusSerialMaster master;
        private SerialPort porta;
        private ushort slv_addr;

        public ushort Slv_addr { get => slv_addr; set => slv_addr = value; }
        public SerialPort Porta { get => porta; set => porta = value; }

        public GM()
        {
            porta = new SerialPort();
            porta.PortName = "COM5";
            porta.BaudRate = 9600;
            porta.Parity = Parity.None;
            porta.StopBits = StopBits.One;
            porta.DataBits = 8;

            master = ModbusSerialMaster.CreateRtu(porta);

            slv_addr = 1;
        }

        //public ushort[] Get_register(ushort slave, ushort address, ref, ushort len)
        public void Get_register(ushort slave, ushort address, ref ushort[] ret, ushort len)
        {
            //ushort[] ret;

            porta.Open();
            ret = master.ReadHoldingRegisters((byte)slave, address, len);
            porta.Close();

            //return ret;
        }

        public void Set_register(ushort slave, ushort addresss, ushort[] data, ushort len)
        {
            porta.Open();
            master.WriteMultipleRegisters((byte)slave, addresss, data);
            porta.Close();
        }

        public ushort get_angulo()
        {
            ushort[] aux = new ushort[1];

            aux[0] = 0;
            Get_register(slv_addr, 44, ref aux, 1);

            return aux[0];
        }

        public void Close()
        {
            master.Dispose();
            master = null;
        }
    }
}
