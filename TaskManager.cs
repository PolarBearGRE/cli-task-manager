namespace TaskManager {
    public class TaskManager {
        static void Main(string[] args) {

            switch (args[0].ToLower()){
                case "add":
                    Console.WriteLine("add");
                    break;
                case "list":
                    Console.WriteLine("list");
                    break;
                case "update":
                    Console.WriteLine("update");
                    break;
                case "delete":
                    Console.WriteLine("delete");
                    break;
                default:
                    Console.WriteLine("Wrong command! Please use one the following commands: add, list, update and delete.");
                    break;
            }
        }
    }
}
