using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Z_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_Trace();

            Console.Read();
        }

        private static void Test_Trace()
        {
            Stream myFile1 = File.Create(@"D:\workstation\KatanaProject\Z_Test\TraceFile1.txt");
            Stream myFile2 = File.Create(@"D:\workstation\KatanaProject\Z_Test\TraceFile2.txt");
            /* Create a new text writer using the output stream, and add it to
                * the trace listeners.
            */
            TextWriterTraceListener myTextTraceListener1 = new TextWriterTraceListener(myFile1);
            TextWriterTraceListener myTextTraceListener2 = new TextWriterTraceListener(myFile2);

            Trace.Listeners.Add(myTextTraceListener1);
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(myTextTraceListener2);

            Trace.Write("Trace output");
            Trace.Flush();
        }

        private static void Test_IEnumerator()
        {

            foreach (var keyValue in new TestIEnumerator())
            {
                //KeyValuePair<string, string> keyValue = (KeyValuePair<string, string>)obj;
                Console.WriteLine("Key:{0}->Value:{1}", keyValue.Key, keyValue.Value);
            }
        }

        private static void Test_Lazy()
        {
            Hero hero = new Hero("wukong");
            Console.WriteLine("\n\n.......................Press Enter to continue.......................\n\n");
            Console.Read();
            Console.WriteLine("Hero's special skill: " + hero.Skill.SkillName);
            Console.Read();
        }
    }

    #region == IEnumerator ==

    public class TestIEnumerator
    {
        private Dictionary<string, string> _appSettings;
        public TestIEnumerator()
        {
            _appSettings = new Dictionary<string, string>();
            _appSettings.Add("a", "Apple");
            _appSettings.Add("b", "Boy");
            _appSettings.Add("c", "Cat");
            _appSettings.Add("d", "Dog");
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (string key in _appSettings.Keys)
            {
                yield return new KeyValuePair<string, string>(key, _appSettings[key]);
            }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return _appSettings.GetEnumerator();
        //}

    }

    #endregion

    #region == Lazy ==

    public class Hero
    {
        public string FullName { get; set; }
        public string Name { get; set; }

        //private readonly Lazy<SpecialSkill> skill;
        //public SpecialSkill Skill
        //{
        //    get
        //    {
        //        return skill.Value;
        //    }
        //}

        private SpecialSkill skill;
        public SpecialSkill Skill
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref skill, () =>
                {
                    return new SpecialSkill(Name);
                });
            }

        }

        public Hero(string name)
        {
            Name = name;
            FullName = "Super " + name;
            //Skill = new SpecialSkill(name);
            //skill = new Lazy<SpecialSkill>(() => { return new SpecialSkill(name); });
        }
    }
    public class SpecialSkill
    {
        public int Power { get; set; }
        public string SkillName { get; set; }
        public int StrengthSpent { get; set; }
        public SpecialSkill(string name)
        {
            Console.WriteLine("loading special skill .....");
            Power = name.Length;
            StrengthSpent = name.Length * 3;
            SkillName = name + " Blazing";
            Console.WriteLine(SkillName + ",... this's what makes a legend!");
        }
    }

    #endregion
}
