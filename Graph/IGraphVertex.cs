using Expert_System_2.Question;

namespace Expert_System_2.Graph
{
    public interface IGraphVertex
    {
        /// <summary>
        /// Название узла 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список вершин с которыми связан данный узел
        /// </summary>
        public List<IGraphVertex> Vertex { get; set; }
        /// <summary>
        /// Список вершин верхнего уровня указывающих на данный узел
        /// </summary>
        public IGraphVertex Upper_Vertex { get; set; }

        /// <summary>
        /// Список фактов
        /// </summary>
        public Dictionary<IGrapgFacts,string> Rules { get; set; }


        /// <summary>
        /// Добавить связь с узлом 
        /// </summary>
        /// <param name="newEdge">Вершина</param>
        public void Add_Edge(IGraphVertex newEdge);


        /// <summary>
        ///  Проверить факты
        /// </summary>
        /// <param name="grapgFacts">Список фактов</param>
        /// <param name="graphVertex_true">Список вершин прошедшие проверку</param>
        /// <param name="graphVertex_False">Список вершин не прошедшие проверку</param>
        public sbyte Checking_Rules(List<IGrapgFacts> grapgFacts, List<IGraphVertex> graphVertex_true, List<IGraphVertex> graphVertex_False);

        // <summary>
        ///  Противоположное прохождение графа
        /// </summary>
        public List<Dictionary<string, string>> Back_Checking_Rules();
        /// <summary>
        ///  Вызвать соотвестующий вопрос 
        /// </summary>
        public Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> Checking_Rules_Question(Tuple<Dictionary<IGrapgFacts, string>, List<IGraphVertex>, bool> input_tuple, IGraphVertex upper_edge);

    }
}
