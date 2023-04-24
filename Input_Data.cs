using Expert_System_2.Graph;
using Expert_System_2.Question;

namespace Expert_System_2
{
    public class Input_Data
    {
        IGrapgFacts rule_1 = new Selection_Question("бюджет", "Каков ваш бюджет для путешествия?", new List<string>
        {
            "малый", "средний","высокий"
        });
        IGrapgFacts rule_2 = new Selection_Question("тип отдыха", "Какой тип отдыха вы предпочитаете? ", new List<string>
        {
            "пляжный ", "активный","культурный"
        });
        IGrapgFacts rule_3 = new Selection_Question("тип активности", "Какой тип активности вам ближе всего? ", new List<string>
        {
            "горные лыжи", "пешие прогулки","велосипедные поездки","катание на водных лыжах"
        });
        IGrapgFacts rule_4 = new Selection_Question("климат", "Какой климат вы предпочитаете?", new List<string>
        {
            "теплый", "холодный","умеренный"
        });
        IGrapgFacts rule_5 = new Selection_Question("тип размещения", "Какой тип размещения вы предпочитаете?", new List<string>
        {
            "отель", "кемпинг","аренда"
        });
        IGrapgFacts rule_6 = new Selection_Question("вид транспорта", "Какой вид транспорта вы хотели бы использовать для перемещений во время поездки?", new List<string>
        {
            "автомобиль", "велосипед"
        });
        IGrapgFacts rule_7 = new Selection_Question("опыт путешествий", "Каков ваш опыт путешествий?", new List<string>
        {
            "опытный", "новичок"
        });
        IGrapgFacts rule_8 = new Selection_Question("интересы", "Каковы ваши интересы?", new List<string>
        {
            "история", "природа","культура","развлечения"
        });

        IGrapgFacts rule_9 = new YesNo_Question("завтрак", "Включен ли завтрак?");
        IGrapgFacts rule_10 = new YesNo_Question("гид", "Нужны ли вам услуги гида?");

        public List<IGraphVertex> Input_list_node()
        {
            var input_list = new List<IGraphVertex>();

            IGraphVertex A = new AND_Node("A", null, new Dictionary<IGrapgFacts, string>
        {
            { rule_1, "средний" },
            { rule_2, "культурный" },
        });
            input_list.Add(A);

            IGraphVertex B = new OR_Node("B", null, new Dictionary<IGrapgFacts, string>
        {
            { rule_3, "пешие прогулки" },
          //  { rule_4, "умеренный" },
            { rule_5, "отель" },
        });
            input_list.Add(B);

            IGraphVertex AB = new AND_Node("AB", new List<IGraphVertex> { A, B }, new Dictionary<IGrapgFacts, string>
        {
            { rule_7, "новичок" },
        });
            input_list.Add(AB);

            IGraphVertex C = new AND_Node("C", null, new Dictionary<IGrapgFacts, string>
        {
            { rule_1, "средний" },
            { rule_2, "активный" },
            { rule_3, "велосипедные поездки" },
        });
            input_list.Add(C);

            IGraphVertex D = new OR_Node("D", null, new Dictionary<IGrapgFacts, string>
        {
            { rule_4, "умеренный" },
            { rule_5, "аренда" },
        });
            input_list.Add(D);

            IGraphVertex CD = new AND_Node("CD", new List<IGraphVertex> { C, D }, new Dictionary<IGrapgFacts, string>
        {
            { rule_8, "природа"},
        });
            input_list.Add(CD);
            return input_list;
        }
    }
}
