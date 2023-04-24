using Expert_System_2.Graph;

namespace Expert_System_2.Graph_Traversal_Algorithm
{
    public class Backward_Chaining
    {
        public List<IGraphVertex> GraphVertices { get; set; }
        public List<Dictionary<string, string>>? Dictionary_List_Fact { get; set; }
        public string Start_Node { get; set; }

        public Backward_Chaining(List<IGraphVertex> graphVertices, string start_node)
        {
            GraphVertices = graphVertices;
            Start_Node = start_node;
        }

        public void Backward_Chaining_Execute()
        {
            foreach (var graphVertex in GraphVertices)
            {
                if (graphVertex.Name == Start_Node)
                {
                    Dictionary_List_Fact = graphVertex.Back_Checking_Rules();
                }
            }
            int count = 0;
            if (Dictionary_List_Fact != null)
                foreach (var dict in Dictionary_List_Fact)
                {
                    count++;
                    Console.WriteLine(count + " список возможных фактов дающих результат " + Start_Node);
                    foreach (var fact in dict)
                    {
                        Console.WriteLine("Признак: " + fact.Key + "; значение: " + fact.Value);
                    }
                    Console.WriteLine();
                }
        }
    }
}
