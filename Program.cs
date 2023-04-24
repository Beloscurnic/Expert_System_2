using Expert_System_2.Graph_Traversal_Algorithm;

namespace Expert_System_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            var list_input = new Input_Data();
            while (flag)
            {
                string nambur_value;
                int value;
                Console.WriteLine("Выбирите алгоритм");
                Console.WriteLine("1. Backward_Chaining");
                Console.WriteLine("2. Forward_Chaining");
                Console.WriteLine("3. Exit");
                Console.Write("Ведите порядковый номер: ");
                nambur_value = Console.ReadLine();
                Console.WriteLine();

                value = Convert.ToInt32(nambur_value);
                if (value == 2)
                {
                    var question_chaining = new Question_Chaining(list_input.Input_list_node());
                    var list_result = question_chaining.Question_Chaining_Execute();
                    foreach (var result in list_result)
                    {
                        Console.Write("На основе выбраных данных получен следующий результат: ");
                        Console.WriteLine(result);
                    }

                    Console.WriteLine();
                }
                if (value == 1)
                {
                    string node_start;
                    Console.Write("Ведите название вершины скакой начать алгоритм: ");
                    node_start = Console.ReadLine();
                    Console.WriteLine();
                    var backward_chaining = new Backward_Chaining(list_input.Input_list_node(), node_start);
                    backward_chaining.Backward_Chaining_Execute();
                }
                if (value == 3) return;
            }
        }
    }
}