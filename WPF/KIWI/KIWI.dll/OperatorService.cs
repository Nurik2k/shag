using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIWI.dll
{
    public class OperatorService
    {
        EntityModel db = new EntityModel();
        public List<Operator> GetOperators()
        {
            List<Operator> operators = new List<Operator>();
            operators = db.Operators.ToList();
            return operators;
        }
        public bool AddOperator(Operator op) 
        {
            try
            {
                db.Operators.Add(op);
                db.SaveChanges();
                return true;
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
