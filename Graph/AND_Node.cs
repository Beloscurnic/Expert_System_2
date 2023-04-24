using Expert_System_2.Question;

namespace Expert_System_2.Graph
{
    public class AND_Node : IGraphVertex
    {
        public string Name { get; set; }
        public List<IGraphVertex>? Vertex { get; set; }
        public IGraphVertex? Upper_Vertex { get; set; }
        public Dictionary<IGrapgFacts, string>? Rules { get; set; }
        bool flag;

        public AND_Node(string name, List<IGraphVertex> edges, IGraphVertex? upper_edges, Dictionary<IGrapgFacts, string> rules)
        {
            Name = name;
            Vertex = edges;
            Upper_Vertex = upper_edges;
            Rules = rules;
        }
        public AND_Node(string name, List<IGraphVertex> edges, Dictionary<IGrapgFacts, string> rules)
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

            if (Rules != null)
                foreach (var grapgFact in grapgFacts)
                {
                    if (Rules.ContainsKey(grapgFact))
                    {
                        string? value = grapgFact.Value;
                        if (!Rules.TryGetValue(grapgFact, out value))
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            if (Vertex != null)
            {
                foreach (var vertex in Vertex)
                {
                    if (!graphVertex_true.Contains(vertex)) return 0;
                    if (graphVertex_false.Contains(vertex)) return -1;
                }
            }
            return 1;
        }

        public List<Dictionary<string, string>> Back_Checking_Rules()
        {
            var result_dictionary_list = new List<Dictionary<string, string>>();
            var temporary_dictionary_list = new List<Dictionary<string, string>>();
            var dictionary = new Dictionary<string, string>();
            if (Vertex != null)
            {
                foreach (var edges in Vertex)
                {
                    var edgest_list_dictionary = edges.Back_Checking_Rules();
                    if (result_dictionary_list.Count == 0)
                    {
                        result_dictionary_list.AddRange(edgest_list_dictionary);
                    }
                    else
                    {
                        foreach(var edgest_dictionary in edgest_list_dictionary)
                        {
                            foreach (var result_dictionary in result_dictionary_list)
                            {                             
                                var temporary_dictionary = new Dictionary<string, string>();
                                temporary_dictionary = edgest_dictionary;
                                foreach (var rules in result_dictionary)
                                {
                                    if (!edgest_dictionary.ContainsKey(rules.Key))
                                    {
                                        temporary_dictionary.Add(rules.Key, rules.Value);
                                    }
                                }
                                temporary_dictionary_list.Add(temporary_dictionary);
                            }
                        }
                        result_dictionary_list = temporary_dictionary_list;
                        temporary_dictionary_list = null;
                    //    result_dictionary_list.AddRange(edgest_list_dictionary);
                    //    foreach (var result_dictionary in result_dictionary_list)
                    //    {
                    //        foreach (var edgest_dictionary in edgest_list_dictionary)
                    //        {
                    //            foreach (var dictionary_key_value in edgest_dictionary)
                    //            {
                    //                if (!result_dictionary.ContainsKey(dictionary_key_value.Key))
                    //                {
                    //                    result_dictionary.Add(dictionary_key_value.Key, dictionary_key_value.Value);
                    //                }
                    //            }
                    //        }
                    //    }
                    }
                }
            }
            if (Rules != null)
            {
                if (result_dictionary_list.Count != 0)
                    foreach (var result_dictionary in result_dictionary_list)
                    {
                        foreach (var rules in Rules)
                        {
                            if (!result_dictionary.ContainsKey(rules.Key.Category_Name))
                            {
                                result_dictionary.Add(rules.Key.Category_Name, rules.Value);
                            }
                        }
                    }
                else
                {
                    foreach (var rules in Rules)
                    {
                        dictionary.Add(rules.Key.Category_Name, rules.Value);
                    }
                    result_dictionary_list.Add(dictionary);
                }
            }
            return result_dictionary_list;
        }

        public Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> Checking_Rules_Question
            (Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> input_tuple, IGraphVertex upper_edge)
        {
            flag = true;
            if (input_tuple.Item3 == true)
            {
                if (Rules != null)
                {
                    foreach (var rule in Rules)
                    {
                        if (!input_tuple.Item1.ContainsKey(rule.Key))
                        {
                            var question = rule.Key.Ask_Question();
                            input_tuple.Item1.Add(rule.Key, question);
                            if (question != rule.Value)
                            {
                                flag = false;
                                break;
                            }
                        }
                        else
                        {
                            string? rule_value = string.Empty;
                            input_tuple.Item1.TryGetValue(rule.Key, out rule_value);
                            if (rule_value != rule.Value)
                                flag = false;
                        }
                    }
                }
                if (Vertex != null)
                {
                    foreach (var edge in Vertex)
                    {
                        if (edge != upper_edge && !input_tuple.Item2.Contains(edge))
                        {
                            input_tuple.Item2.Add(edge);
                            var tuple = edge.Checking_Rules_Question(Tuple.Create(input_tuple.Item1, input_tuple.Item2, flag), null);
                            foreach (var dictionary in tuple.Item1)
                            {
                                if (!input_tuple.Item1.ContainsKey(dictionary.Key))
                                    input_tuple.Item1.Add(dictionary.Key, dictionary.Value);

                            }
                            foreach (var list2 in tuple.Item2)
                            {
                                if (!input_tuple.Item2.Contains(list2)) input_tuple.Item2.Add(list2);
                            }
                            if (tuple.Item3 == false)
                                flag = false;
                        }
                    }
                }
                return Tuple.Create(input_tuple.Item1, input_tuple.Item2, flag);
            }
            else
            {
                flag = input_tuple.Item3;
                if (Vertex != null)
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
                                if (!input_tuple.Item2.Contains(list2)) input_tuple.Item2.Add(list2);
                            }
                        }
                    }
                return Tuple.Create(input_tuple.Item1, input_tuple.Item2, flag);
            }
        }
    }
}

