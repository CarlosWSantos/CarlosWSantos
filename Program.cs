using System;
using System.Collections.Generic;


public class Player
{
    public string nome;
    public int xp;
    public int gold;
    public List<Item> Itens = new List<Item>();
}

public class Item
{
    public string Nome;
    public int Id;
    public int Preco;

        public Item(String Nome, Int Id, Int Preco)
        {
            this.Nome = Nome;
            this.Id = Id;
            this.Preco = Preco;
        }
}

public class LP2_Trabalho
{

    static List<Player> Players = new List<Player>();

    public static void Main(string[] args)
    {
     
        
        bool MostrarMenu = true;
        while (MostrarMenu)
        {
            MostrarMenu = MenuPrincipal();
        }
    }


    private static bool MenuPrincipal()
    {
            Item machado = new Item("Boomachado", 506, 55);

            Item growsword = new Item("Grow up Sword", 696, 100);
            
            Item rsword = new Item("Rusted Sword", 001, 20);

            Item bow = new Item("Heavy Bow", 59, 90);

            Item bomba = new Item("Last Bomb", 700, 75);

        Console.Clear();
        Console.WriteLine("Entre com '1' para criar um jogador (necessário para entrar na loja).");
        Console.WriteLine("Entre com '2' para checar as informações de todos os jogadores criados.");
        Console.WriteLine("Entre com '3' para olhar o seu inventário.");
        Console.WriteLine("Entre com '4' para entrar na loja.");
        Console.WriteLine("Entre com '5' para encerrar o programa.");

        switch (Console.ReadLine())
        {
            case "1":

                Console.Clear();  
                
                Console.Write("Digite o nome do seu jogador: ");
                var np = Console.ReadLine();
              
                Console.Write("Digite a quantidade de XP (experiência): ");
                var xpP = Console.ReadLine();
               
                Random randNum = new Random();
                var dinDin = randNum.Next(50, 350);


                Players.Add(new Player { nome = np, xp = Convert.ToInt32(xpP), gold = dinDin});
                Console.Clear();

                Console.WriteLine("Jogador criado com sucesso");
                Console.WriteLine("");
                Console.WriteLine("Verifique o seu gold (gerado de forma aleatoria): " + dinDin);
                Console.WriteLine("Tecle 'ENTER' para continuar...");
                Console.ReadLine();
                return true;

            case "2":
                Console.Clear();
                for (int i = 0; i < Players.Count; i++)
                {

                    Console.WriteLine("");
                    Console.WriteLine("Jogador:");            
                    Console.WriteLine("Nome : " + Players[i].nome);
                    Console.WriteLine("XP : " + Players[i].xp);
                    Console.WriteLine("Gold : " + Players[i].gold);                 
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.Write("Pressione qualquer tecla para sair...");
                Console.ReadKey();
                return true;
            
            case "3":
            Console.Clear();
            Console.WriteLine("Digite o nome do jogador para verificar o iventário:");
            var pq = Console.ReadLine();
            foreach(Player p in Players)
            {
                if(p.nome == pq)
                {
                    Console.WriteLine("Itens:");
                    Console.WriteLine("");
                    for (int i = 0; i < p.Itens.Count; i++)
                    {
                        Console.WriteLine("Item: " + p.Itens[i].Nome);
                    }
                    Console.WriteLine("Entre com qualquer tecla para continuar");
                    Console.ReadLine();
                }
                else{
                    Console.Clear();
                    Console.WriteLine("Nenhum jogador encontrado... Retornando ao menu principal");
                    Console.ReadLine();
                }
            }
                return true;

            case "4":
            Console.Clear();
            Console.WriteLine("Digite o nome do jogador que irá acessar a loja: ");
            pq = Console.ReadLine();
            foreach(Player p in Players)
            {
                if(p.nome == pq)
                {
                    Console.WriteLine("-Velho Phill");
                    Console.WriteLine("Olá estranho! Veio passear na minha loja? Cuidado com o que compra. Hehehehe");
                    Console.WriteLine("-Digite o ID do item que você gostaria de comprar:");
                    Console.WriteLine("");
                    Console.WriteLine("506 - Boomachado 250BSA (eff: Após o dano normal o machado dá 10% do seu dano base no inimigo)");
                    Console.WriteLine("");
                    Console.WriteLine("696 - Grow-Up Sword 90BSA (eff: A cada dano dado a um oponente em uma batalha o dano base da espada)");
                    Console.WriteLine("é aumentado em 20. Este efeito volta a 0 no final da batalha).");
                    Console.WriteLine("");
                    Console.WriteLine("001 - Rusted Sword 50BSA (eff: Uma espada danificada de pedra.)");
                    Console.WriteLine("");
                    Console.WriteLine("059 - Heavy Bbow 30BSA (eff: Pode ser usado como arma corpo a corpo ou longa distância)");
                    Console.WriteLine("");
                    Console.WriteLine("700 - Last Bomb 0BSA (eff: Elimina um inimigo aleatório da batalha. Este item é apagado)");
                    Console.WriteLine("do iventário após o uso.");
                    Console.WriteLine("");
                    var ic = Console.ReadLine();
                    switch(ic)
                    {
                        case "506":
                        Console.WriteLine("Você gostaria de comprar Boomachado por 100G? (S)/(N)");
                        Console.WriteLine("Seu ouro:" + p.gold);
                        var resp = Console.ReadLine();
                        if(resp == "S")
                        {
                            if(p.gold >= machado.Preco)
                            {
                                p.gold = p.gold - machado.Preco;
                                p.Itens.Add(machado);
                                Console.Clear();
                                Console.WriteLine("-Item adicionado ao iventário com sucesso!");
                                Console.WriteLine("-Velho Phill");
                                Console.WriteLine("Hehehe. Muito obrigado, volte sempre!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Você quer me roubar? Quer comprar má não tem dinheiro. Sai daqui!");
                                Console.ReadLine();
                            }
                        }
                        else{}
                        break;

                        case "696":
                        Console.WriteLine("Você gostaria de comprar Grow-Up Sword por 100G? (S)/(N)");
                        Console.WriteLine("Seu ouro:" + p.gold);
                 
                        resp = Console.ReadLine();
                        if(resp == "S")
                        {
                            if(p.gold >= growsword.Preco)
                            {
                                p.gold = p.gold - growsword.Preco;
                                p.Itens.Add(growsword);
                                Console.Clear();
                                Console.WriteLine("-Item adicionado ao iventário com sucesso!");
                                Console.WriteLine("-Velho Phill");
                                Console.WriteLine("Hehehe. Muito obrigado, volte sempre!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Você quer me roubar? Quer comprar má não tem dinheiro >:( . Sai daqui!");
                                Console.ReadLine();
                            }
                        }
                        else{}
                        break;

                        case "001":
                        Console.WriteLine("Você gostaria de comprar Rusted Sword por 20G? (S)/(N)");
                        Console.WriteLine("Seu ouro:" + p.gold);
                        resp = Console.ReadLine();
                        if(resp == "S")
                        {
                            if(p.gold >= rsword.Preco)
                            {
                                p.gold = p.gold - rsword.Preco;
                                p.Itens.Add(rsword);
                                Console.Clear();
                                Console.WriteLine("-Item adicionado ao iventário com sucesso!");
                                Console.WriteLine("-Velho Phill");
                                Console.WriteLine("Hehehe. Muito obrigado, volte sempre!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Você quer me roubar? Quer comprar má não tem dinheiro >:( . Sai daqui!");
                                Console.ReadLine();
                            }
                        }
                        else{}
                        break;

                        case "059":
                        Console.WriteLine("Você gostaria de comprar Bbow por 90G? (S)/(N)");
                        Console.WriteLine("Seu ouro:" + p.gold);
                        resp = Console.ReadLine();
                        if(resp == "S")
                        {
                            if(p.gold >= bow.Preco)
                            {
                                p.gold = p.gold - bow.Preco;
                                p.Itens.Add(bow);
                                Console.Clear();
                                Console.WriteLine("-Item adicionado ao iventário com sucesso!");
                                Console.WriteLine("-Velho Phill");
                                Console.WriteLine("Hehehe. Muito obrigado, volte sempre!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Você quer me roubar? Quer comprar má não tem dinheiro >:( . Sai daqui!");
                                Console.ReadLine();
                            }
                        }
                        else{}
                        break;

                        case "700":
                        Console.WriteLine("Você gostaria de comprar Last Bomb por 75G? (S)/(N)");
                        Console.WriteLine("Seu ouro:" + p.gold);
                        resp = Console.ReadLine();
                        if(resp == "S")
                        {
                            if(p.gold >= bomba.Preco)
                            {
                                p.gold = p.gold - bomba.Preco;
                                p.Itens.Add(bomba);
                                Console.Clear();
                                Console.WriteLine("-Item adicionado ao iventário com sucesso!");
                                Console.WriteLine("-Velho Phill");
                                Console.WriteLine("Hehehe. Muito obrigado, volte sempre!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Você quer me roubar? Quer comprar má não tem dinheiro >:( . Sai daqui!");
                                Console.ReadLine();
                            }
                        }
                        else{}
                        break;

                        default:
                        Console.WriteLine("-Velho Phill");
                        Console.WriteLine("Seu pamonha! Vem aqui e não compra nada!");
                        Console.ReadLine();
                        break;
                    }
                }
                else{
                    Console.Clear();
                    Console.WriteLine("Nenhum jogador encontrado... É necessário ter um jogador registrado");
                    Console.WriteLine("para acessar a loja. Retornando ao menu principal...");
                    Console.ReadLine();
                }
            }
                return true;

            case "5":
                return false;

            default:
                return true;

        }
    }


}