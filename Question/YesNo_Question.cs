using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert_System_2.Question
{
    public class YesNo_Question : IGrapgFacts
    {
        public string? Value { get; set; }
        public string Category_Name { get; set; }
        public string Description { get; set; }
        public List<string>? Value_list { get; set; }
     

        public YesNo_Question(string description,string category_name)
        {
            Category_Name = category_name;  
            Description = description;
        }

        public YesNo_Question(string value, string category_name, string description)
        {
            Value = value;
            Category_Name=category_name;
            Description = description;     
        }
        public string Ask_Question()
        {
            Console.WriteLine(Description);
            Console.Write("Ответьте Да/Нет:");           
            Value = Console.ReadLine();
            Console.WriteLine();
            if (Value != null)
                return Value;
            else return String.Empty;
        }
    }
}
