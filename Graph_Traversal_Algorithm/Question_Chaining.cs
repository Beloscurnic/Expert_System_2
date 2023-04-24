using Expert_System_2.Graph;
using Expert_System_2.Question;
using System.ComponentModel;

namespace Expert_System_2.Graph_Traversal_Algorithm
{
    public class Question_Chaining
    {

        public List<IGraphVertex> Vertex { get; set; }
        public Dictionary<IGrapgFacts, string>? Rules { get; set; }

        public Question_Chaining(List<IGraphVertex> edges)
        {
            Vertex = edges;
        }

        public List<string> Question_Chaining_Execute()
        {
            var Rules = new Dictionary<IGrapgFacts, string>();
            var peaks_visited = new List<IGraphVertex>();
            var result = new List<string>();
            foreach (var vertex in Vertex)
            {
                if (!peaks_visited.Contains(vertex))
                {
                    var result_vertex = vertex.Checking_Rules_Question(Tuple.Create(Rules, peaks_visited, true), null);
                    result_vertex.Item2.Add(vertex);

                    var upper_vertex = vertex.Upper_Vertex;
                    var vertex_this = vertex;
                    while (true)
                    {
                        if (upper_vertex != null)
                        {
                            result_vertex.Item2.Add(upper_vertex);
                            var upper_vertex_result = upper_vertex.Checking_Rules_Question(result_vertex, vertex_this);
                            if (upper_vertex_result.Item3 == true && upper_vertex.Upper_Vertex ==null)
                            { 
                                result.Add(upper_vertex.Name); 
                            }
                            result_vertex = upper_vertex_result;
                            vertex_this = upper_vertex;
                            upper_vertex = upper_vertex.Upper_Vertex;
                        }
                        else
                        {                         
                            break;
                        }
                    }
                   // peaks_visited.AddRange(result_vertex.Item2);
                }
            }
            return result;
        }
    }
}
