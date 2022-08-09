namespace SincAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Delegando para o computador para executar esses métodos
            var t1 = Falar("Aoba", 5);
            var t2 = Gritar("Uhul", 15);
            var t3 = Falar("hey", 2);
            var t4 = GritarMuito("oi", 40);
            var t5 = Falar("nussa", 6);
            var t6 = Falar("oxente", 7);

            await t1;
            await t2;
            await t3;
            await t4;
            await t5;
            await t6;


            Console.WriteLine($"Já passei por aqui e vou enviar para a CPU executar a busca no DB -  {DateTime.Now}");
            var taskBuscarNoDB = BuscarNoDB(2000);
            var taskBuscarNoDB2 = BuscarNoDB(5000);
            Console.WriteLine($"Já deleguei a tarefa... Estou aguardando o resultado... {DateTime.Now}");
            var resultado = await taskBuscarNoDB;
            Console.WriteLine($"O resultado foi {resultado} em  {DateTime.Now}");
            var resultado2 = await taskBuscarNoDB2;
            Console.WriteLine($"O resultado foi {resultado2} em  {DateTime.Now}");
        }

        private static async Task<int> BuscarNoDB(int timeout)
        {
            //Suponha que o resultado venha do DB, e esse DB demore 200ms para retornar o resultado...
            await Task.Delay(timeout);
            return 8;
        }

        private static async Task Falar(string msg, int quantidade)
        {
            Console.WriteLine($"Iniciando o método FALAR com a mensagem: {msg}, rodando {quantidade} vezes");
            await Task.Delay(2000);
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"{Desenhar(quantidade - i)} - {msg} - {i}");
                await Task.Delay(1000);
            }
        }

        private static async Task Gritar(string msg, int quantidade)
        {
            Console.WriteLine($"Iniciando o método GRITAR com a mensagem: {msg}, rodando {quantidade} vezes");
            await Task.Delay(2000);
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"{Desenhar(quantidade - i)} - {msg} - {i}");
                await Task.Delay(200);
            }
        }

        private static async Task GritarMuito(string msg, int quantidade)
        {
            Console.WriteLine($"Iniciando o método GRITAR MUITO com a mensagem: {msg}, rodando {quantidade} vezes");
            await Task.Delay(100);
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"{Desenhar(quantidade - i)} - {msg} - {i}");
                await Task.Delay(100);
            }
        }

        private static string Desenhar(int quantidade)
        {
            string tabs = new('#', quantidade);
            return $"[{tabs}]";
        }
    }
}