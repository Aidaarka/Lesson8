using MySql.Data.MySqlClient;
using System;

namespace Lesson8
{
    class Lesson8
    {
        static void Main(string[] args)
        {
            string server = "localhost";
            string database = "computercourses";
            string login = "root";
            string pass = "root";

            string sqlConnect = "Database=" + database + ";Datasource=" + server + ";user=" + login + ";Password=" + pass;

            MySqlConnection connect = new MySqlConnection(sqlConnect);

            connect.Open();

            string getAll;
            string getInfo;
            string delete;
            string getStudents;

            Console.WriteLine("Введите команду:\nGET ALL - вывод в консоль информации о всех студентах" +
                                                "\nGET INFO - вывести информацию о студенте" +
                                                "\nDELETE - удалить студента по имени");

            string command = Console.ReadLine();
            if (command == "GET ALL")
            {
                getAll = "select * from students";
                MySqlCommand queryAll = new MySqlCommand(getAll, connect);
                MySqlDataReader readerAll = queryAll.ExecuteReader();

                while (readerAll.Read())
                {
                    Console.WriteLine("Имя {0}, оценка {1}", readerAll["Full_name"], readerAll["mark"]);
                }
                readerAll.Close();
            }

            else if (command == "GET INFO")
            {
                Console.WriteLine("Введите ФИО студента из списка, информацию о котором вы хотите получить.");

                getStudents = "select Full_name from students";
                MySqlCommand queryName = new MySqlCommand(getStudents, connect);
                MySqlDataReader readerName = queryName.ExecuteReader();
                while (readerName.Read())
                {
                    Console.WriteLine("ФИО {0}", readerName["Full_name"]);
                }
                readerName.Close();

                string fullName = Console.ReadLine();
                getInfo = $"select * from students where Full_name= '{fullName}'";
                MySqlCommand queryInf = new MySqlCommand(getInfo, connect);
                MySqlDataReader readerInf = queryInf.ExecuteReader();
                while (readerInf.Read())
                {
                    Console.WriteLine("Имя {0}, оценка {1}", readerInf["Full_name"], readerInf["mark"]);
                }
                readerInf.Close();
            }

            else if (command == "DELETE")
            {
                Console.WriteLine("Выберете студента из списка и введите его ФИО, чтобы удалить.");

                getStudents = "select Full_name from students";
                MySqlCommand queryName = new MySqlCommand(getStudents, connect);
                MySqlDataReader readerName = queryName.ExecuteReader();
                while (readerName.Read())
                {
                    Console.WriteLine("ФИО {0}", readerName["Full_name"]);
                }
                readerName.Close();

                string fullName = Console.ReadLine();
                delete = $"delete from students where Full_name= '{fullName}' limit 1";
                MySqlCommand queryDel = new MySqlCommand(delete, connect);
                MySqlDataReader readerDel = queryDel.ExecuteReader();
                while (readerDel.Read())
                {
                    Console.WriteLine("Удаление студента: Имя {0}, оценка {1}", readerDel["Full_name"], readerDel["mark"]);
                }
                readerDel.Close();
                Console.WriteLine("Студент успешно удален из списка!");
            }

            connect.Close();
        }
    }
}
