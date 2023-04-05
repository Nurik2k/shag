using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.State
{
    abstract class TCPState
    {
        public abstract void Open(TCPConnection c);
        public abstract void Close(TCPConnection c);
        public abstract void Acknowledge(TCPConnection c);
    }
    class TCPListen : TCPState
    {
        public override void Acknowledge(TCPConnection c)
        {
            c.Acknowledge();
            c.ChangeState(new TCPEstablished());
        }
        public override void Close(TCPConnection c)
        {
            c.Close();
            c.ChangeState(new TCPClosed());
        }
        public override void Open(TCPConnection c)
        {
            c.Open();
            c.ChangeState(new TCPListen());
        }
    }
    class TCPClosed : TCPState
    {
        public override void Acknowledge(TCPConnection c)
        {
            c.Acknowledge();
            c.ChangeState(new TCPEstablished());
        }
        public override void Close(TCPConnection c)
        {
            c.Close();
            c.ChangeState(new TCPClosed());
        }
        public override void Open(TCPConnection c)
        {
            c.Open();
            c.ChangeState(new TCPListen());
        }
    }
    class TCPEstablished : TCPState
    {
        public override void Acknowledge(TCPConnection c)
        {
            c.Acknowledge();
            c.ChangeState(new TCPEstablished());
        }
        public override void Close(TCPConnection c)
        {
            c.Close();
            c.ChangeState(new TCPClosed());
        }
        public override void Open(TCPConnection c)
        {
            c.Open();
            c.ChangeState(new TCPListen());
        }
    }
    class TCPConnection
    {
        private TCPState state;
        public TCPConnection(TCPState s)
        {
            state = s;
        }
        public void Open()
        {
            state.Open(this);
        }
        public void Close()
        {
            state.Close(this);
        }
        public void Acknowledge()
        {
            state.Acknowledge(this);
        }
        public void ChangeState(TCPState s)
        {
            state = s;
        }
    }
    class Client
    {
        public void Execute()
        {
            TCPConnection connection = new TCPConnection(new TCPClosed());

            connection.Open();
            connection.Acknowledge();
            connection.Close();
        }
    }
}
