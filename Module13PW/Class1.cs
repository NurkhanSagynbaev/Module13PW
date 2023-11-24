using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13PW
{
    public class Client
    {
        public int Id { get; }
        public string Name { get; }
        public ServiceType ServiceType { get; }
        public DateTime ArrivalTime { get; }

        public Client(int id, string name, ServiceType serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
            ArrivalTime = DateTime.Now;
        }
    }

    // Перечисление типов обслуживания
    public enum ServiceType
    {
        Credit,
        Deposit,
        Consultation
    }

    // Класс банка
    public class Bank
    {
        private Queue<Client> clientQueue = new Queue<Client>();

        // Добавление клиента в очередь
        public void EnqueueClient(Client client)
        {
            clientQueue.Enqueue(client);
            Console.WriteLine($"Клиент {client.Name} ({client.ServiceType}) добавлен в очередь.");
            DisplayQueue();
        }

        // Обслуживание следующего клиента
        public void ServeNextClient()
        {
            if (clientQueue.Count > 0)
            {
                Client nextClient = clientQueue.Dequeue();
                Console.WriteLine($"Обслужен клиент {nextClient.Name} ({nextClient.ServiceType}).");
                DisplayQueue();
            }
            else
            {
                Console.WriteLine("Очередь пуста.");
            }
        }

        // Отображение текущего состояния очереди
        private void DisplayQueue()
        {
            Console.WriteLine("Текущая очередь:");
            foreach (var client in clientQueue)
            {
                Console.WriteLine($"Клиент {client.Name} ({client.ServiceType})");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Bank bank = new Bank();

            // Пример использования
            Client client1 = new Client(1, "Иван", ServiceType.Credit);
            Client client2 = new Client(2, "Мария", ServiceType.Consultation);

            bank.EnqueueClient(client1);
            bank.EnqueueClient(client2);

            bank.ServeNextClient();
        }
    }

}
