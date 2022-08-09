namespace SincAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var t1 = Falar("Aoba", 5);
            var t2 = Falar("Uhul", 15);
            var t3 = Falar("hey", 2);
            var t4 = Falar("oi", 4);
            var t5 = Falar("nussa", 6);
            var t6 = Falar("oxente", 7);

            await t1;
            await t2;
            await t3;
            await t4;
            await t5;
            await t6;
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

        private static string Desenhar(int quantidade)
        {
            string tabs = new('#', quantidade);
            return $"[{tabs}]";
        }
    }
}