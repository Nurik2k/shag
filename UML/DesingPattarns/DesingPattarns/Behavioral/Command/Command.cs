using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Command
{
    abstract class Command
    {
        public abstract void Execute();
    }
    class SQLConnector
    {
        public void BackupMethod()
        {
            Console.WriteLine("Выполнение операций по выгрузке в архив");
        }
        public void ReIndexMethod()
        {
            Console.WriteLine("Выполнение операций по перезаписи индексов");
        }
    }
    class ReIndex : Command
    {
        private SQLConnector _sql;
        public ReIndex(SQLConnector obj)
        {
            _sql = obj;
        }
        public override void Execute()
        {
            _sql.ReIndexMethod();
        }
    }
    class Backup : Command
    {
        private SQLConnector _sql;
        public Backup(SQLConnector obj)
        {
            _sql = obj;
        }
        public override void Execute()
        {
            _sql.BackupMethod();
        }
    }
    class Client
    {
        public void MainExecute()
        {
            Command obj = new Backup(new SQLConnector());
            obj.Execute();
            obj = new ReIndex(new SQLConnector());
            obj.Execute();
        }
    }
}
