using Expert_System_2.Graph;
using Expert_System_2.Question;

namespace Expert_System_2.Graph_Traversal_Algorithm
{
    public class Chaining
    {
        //public List<IGraphVertex> GraphVertices { get; set; }
        //public List<IGrapgFacts> GrapgFacts { get; set; }

        //public IGraphVertex? Result { get; set; }
        //public Forward_Chaining(List<IGraphVertex> graphVertices, List<IGrapgFacts> grapgFacts)
        //{
        //    GraphVertices = graphVertices;
        //    GrapgFacts = grapgFacts;
        //}

        //public string Forward_Chaining_Execute()
        //{
        //    var unclaimed_rules = new List<IGraphVertex>();
        //    var unreachable_rules = new List<IGraphVertex>();
        //    var graphVertex_true = new List<IGraphVertex>();
        //    var graphVertex_false = new List<IGraphVertex>();

        //    bool flag = true;

        //    while (flag)
        //    {
        //        flag = false;
        //        Result = null;
        //        foreach (IGraphVertex vertex in GraphVertices)
        //        {
        //            if (!unclaimed_rules.Contains(vertex))
        //            {
        //                sbyte check = vertex.Checking_Rules(GrapgFacts, graphVertex_true, graphVertex_false);
        //                if (check == 1 || check == -1)
        //                { 
        //                    flag = true;
        //                    unclaimed_rules.Add(vertex);
        //                    if (check == 1)
        //                    {
        //                        Result = vertex;
        //                        graphVertex_true.Add(vertex);
        //                    }
        //                    if (check == -1) graphVertex_false.Add(vertex);
        //                }
        //                if (check == 0)
        //                {
        //                    unreachable_rules.Add(vertex);
        //                }
        //            }
        //        }
        //    }
        //    if (Result != null)
        //        return Result.Name;
        //    else return String.Empty;
        //}
    }
}
