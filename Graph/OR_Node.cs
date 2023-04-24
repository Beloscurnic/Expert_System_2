using Expert_System_2.Question;

namespace Expert_System_2.Graph
{
    public class OR_Node : IGraphVertex
    {
        public string Name { get; set; }
        public List<IGraphVertex> Vertex { get; set; }
        public IGraphVertex? Upper_Vertex { get; set; }
        public Dictionary<IGrapgFacts, string> Rules { get; set; }
        bool flag;
        bool flag_result_edge;
        public OR_Node(string name, List<IGraphVertex> edges, Dictionary<IGrapgFacts, string> rules)
        {
            Name = name;
            Vertex = edges;
            if (edges != null)
            {
                foreach (var edge in edges)
                {
                    edge.Upper_Vertex = this;
                }
            }
            Rules = rules;
        }
        public OR_Node(string name, List<IGraphVertex> edges, IGraphVertex upper_edges, Dictionary<IGrapgFacts, string> rules)
        {
            Name = name;
            Vertex = edges;
            Upper_Vertex = upper_edges;
            Rules = rules;
        }
        public void Add_Edge(IGraphVertex newEdge)
        {
            if (!Vertex.Contains(newEdge))
            {
                Vertex.Add(newEdge);
                newEdge.Upper_Vertex = this;
            }
        }

        public sbyte Checking_Rules(List<IGrapgFacts> grapgFacts, List<IGraphVertex> graphVertex_true, List<IGraphVertex> graphVertex_false)
        {
            //int count = 0;
            //if (Rules != null)
            //    foreach (var grapgFact in grapgFacts)
            //    {
            //        if (Rules.ContainsKey(grapgFact))
            //        {
            //            string? value = grapgFact.Value;
            //            if (!Rules.TryGetValue(grapgFact, out value))
            //            {
            //                count++;
            //                continue;
            //            }
            //            else
            //            {
            //                return 1;
            //            }
            //        }
            //    }

            //if (Rules.Count == count && Vertex == null) return -1;

            //count = 0;
            //if (Vertex != null)
            //{
            //    foreach (var vertices in Vertex)
            //    {
            //        if (!graphVertex_true.Contains(vertices))
            //        {
            //            count++;
            //            continue;
            //        }
            //        else return 1;
            //    }
            //    if (Vertex.Count == count)
            //    {
            //        return -1;
            //    }
            //}
            //return 0;
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> Back_Checking_Rules()
        {
            var result_dictionary_list = new List<Dictionary<string, string>>();
            var temporary_dictionary_list = new List<Dictionary<string, string>>();

            if (Vertex != null)
            {
                foreach (var edges in Vertex)
                {
                    result_dictionary_list.AddRange(edges.Back_Checking_Rules());
                }
            }
            if (Rules != null)
            {
                foreach (var rules in Rules)
                {
                    bool flag = true;
                    var dictionary = new Dictionary<string, string>();
                    if (Vertex != null)
                    {
                        foreach (var result_dictionary in result_dictionary_list)
                        {
                            if (result_dictionary.ContainsKey(rules.Key.Category_Name))
                            {                              
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            dictionary.Add(rules.Key.Category_Name, rules.Value);
                            temporary_dictionary_list.Add(dictionary);
                        }
                    }
                    else
                    {
                        dictionary.Add(rules.Key.Category_Name, rules.Value);
                        temporary_dictionary_list.Add(dictionary);
                    }
                }
            }
            result_dictionary_list.AddRange(temporary_dictionary_list);
            return result_dictionary_list;
        }

        public Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> Checking_Rules_Question
        (Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> input_tuple, IGraphVertex upper_edge)
        {
            flag = true;
            flag_result_edge = true;
            //var dictionary_result = new Dictionary<IGrapgFacts, string>();
            //var edgest_result = new List<IGraphVertex>();

            if (upper_edge != null && input_tuple.Item3 == true)
            {
                flag = false;
            }
            if (input_tuple.Item3 == true)
            {
                if (Rules != null && flag == true)
                {
                    foreach (var rule in Rules)
                    {
                        if (!input_tuple.Item1.ContainsKey(rule.Key))
                        {
                            var question = rule.Key.Ask_Question();
                            input_tuple.Item1.Add(rule.Key, question);
                            if (question != rule.Value) continue;
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                        else
                        {
                            string? rule_value = string.Empty;
                            input_tuple.Item1.TryGetValue(rule.Key, out rule_value);
                            if (rule_value == rule.Value)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
                if (Vertex != null)
                {
                    int count = 0;
                    foreach (var edge in Vertex)
                    {
                        if (edge != upper_edge && !input_tuple.Item2.Contains(edge))
                        {
                            input_tuple.Item2.Add(edge);
                            var tuple = edge.Checking_Rules_Question(Tuple.Create(input_tuple.Item1, input_tuple.Item2, flag), null);
                            foreach (var dictionary in tuple.Item1)
                            {
                                if (!input_tuple.Item1.ContainsKey(dictionary.Key))
                                {
                                    input_tuple.Item1.Add(dictionary.Key, dictionary.Value);
                                }
                            }
                            foreach (var list2 in tuple.Item2)
                            {
                                if (!input_tuple.Item2.Contains(list2))
                                {
                                    input_tuple.Item2.Add(list2);
                                }
                            }
                            if (tuple.Item3 == true)
                            {
                                flag = false;
                            }
                            else
                            {
                                count++;
                            }
                        }
                    }
                    if (count == Vertex.Count)
                        flag_result_edge = false;
                }
                return Tuple.Create(input_tuple.Item1, input_tuple.Item2, flag_result_edge);
            }
            else
            {
                if (Vertex != null)
                {
                    foreach (var edge in Vertex)
                    {
                        if (edge != upper_edge && !input_tuple.Item2.Contains(edge))
                        {
                            input_tuple.Item2.Add(edge);
                            var tuple = edge.Checking_Rules_Question(Tuple.Create(input_tuple.Item1, input_tuple.Item2, false), null);
                            foreach (var dictionary in tuple.Item1)
                            {
                                if (!input_tuple.Item1.ContainsKey(dictionary.Key))
                                {
                                    input_tuple.Item1.Add(dictionary.Key, dictionary.Value);
                                }
                            }
                            foreach (var list2 in tuple.Item2)
                            {
                                if (!input_tuple.Item2.Contains(list2)) input_tuple.Item2.Add(list2);
                            }
                        }
                    }
                }
                return Tuple.Create(input_tuple.Item1, input_tuple.Item2, false);
            }
        }

    }
}

