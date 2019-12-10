using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public abstract class Book : NamedObject, IBook{
        public Book(string name) : base(name){
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public interface IBook{
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }

    public class InMemoryBook : Book{
        private List<double> grades;
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name) {
            Name = name;
            grades = new List<double>();
        }

        public override void AddGrade(double grade){
            if(grade <= 100 && grade >= 0){
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else
                System.Console.WriteLine("Invalid Value");            
        }

        public override Statistics GetStatistics(){
            Statistics result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

    }
}