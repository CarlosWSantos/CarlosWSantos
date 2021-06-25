using System.Diagnostics.Tracing;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Aula14
{

  public class Assinatura : Licensa
{
    private int duration;

    public double Duracao
    {
        get { return this.duration; }
    }

    public Assinatura(string nome, double mensalidade, int duracao, string chaveAtivacao) : base(nome, mensalidade, chaveAtivacao)
    {
        this.duration = duracao;
    }

    public override double CalculaValorTotal()
    {
        return this.price * this.duration;
    }
    
    public override void Imprimir()
    {
        Console.WriteLine("Software:\t{0}", this.Nome); 
        Console.WriteLine("Mensalidade:\tR$ {0:0.00}", this.price);
        Console.WriteLine("Duração:\t{0}", this.duration);
        Console.WriteLine("Valor:\t\tR$ {0:0.00}", this.CalculaValorTotal());
    }
}

public class Carrinho
{
    private Dictionary<Produto, int> ite;

    public Dictionary<Produto, int> Itens
    {
        get { return this.ite; }
    }

    public double Total
    {
        get
        {
            double somatorio = 0;
            // somatorio de valor total de cada item multiplicado pela quantidade de itens no carrinho
            foreach (KeyValuePair<Produto, int> parOrdenado in this.ite)
                somatorio += parOrdenado.Key.CalculaValorTotal() * parOrdenado.Value;

            return somatorio;
        }
    }

    public Carrinho()
    {
        this.ite = new Dictionary<Produto, int>();
    }
    
    public void Adicionar(Produto item, int quantidade)
    {
        if (this.ite.ContainsKey(item))
            this.ite[item] = this.ite[item] + quantidade;
        else
            this.ite[item] = quantidade;
    }

    public void Adicionar(Produto item)
    {
        this.Adicionar(item, 1);
    }
    
    public void Adicionar(List<Produto> itens)
    {
        foreach (var item in itens)
        {
            this.Adicionar(item);
        }
    }
    
    public void Adicionar(Dictionary<Produto, int> itens)
    {
        foreach (KeyValuePair<Produto, int> parOrdenado in itens)
        {
            this.Adicionar(parOrdenado.Key, parOrdenado.Value);
        }
    }



  



    public void ImprimirCarrinho()
    {
        Console.WriteLine("======== CARRINHO ========");
        foreach (KeyValuePair<Produto, int> parOrdenado in this.ite)
        {
            parOrdenado.Key.Imprimir();
            Console.WriteLine("Quantidade:\t{0}", parOrdenado.Value);
            Console.WriteLine("Subtotal:\tR$ {0:0.00}", parOrdenado.Value * parOrdenado.Key.CalculaValorTotal());
            Console.WriteLine("==========================");
        }
        Console.WriteLine("Total do carrinho:\tR$ {0:0.00}", this.Total);
        Console.WriteLine("==========================");
    }
}

public class Cliente : IImprimivel
    {
        private string name;
        private string cPf;

        public string Nome
        {
            get
            {
                return this.name;
            }
        }

        public string Cpf
        {
            get
            {
                return this.cPf;
            }
        }

        public Cliente(string nome, string cpf)
        {
            this.name = nome;
            this.cPf = cpf;
        }
        public void Imprimir()
        {
            Console.WriteLine("Nome:\t{0}", this.Nome); 
            Console.WriteLine("CPF:\t{0}", this.Cpf);
        }
    }

    public class Compras
{
    private Compra_Atributos comprAtributos;
    private Carrinho caR;
    private Estoque est;




        public Compras(Carrinho carrinho_, Estoque estoque_, Cliente cliente_ )
        {
            this.comprAtributos = new Compra_Atributos(cliente_);
            this.caR = carrinho_;
            this.est = est;      
        }



        //========================================
        //========================================
        //========================================
        public bool Conferir_Estoque()
        {
                    
        foreach (var item in caR.Itens)
            {
                var search = est.Itens.FirstOrDefault(x => x.Key.Nome == item.Key.Nome);   

                if(item.Value > search.Value)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"O Estoque não possui \"{item.Key.Nome}\" suficientes para a compra - [\"{item.Value}\" Unidades no carrinho / \"{autoSearch2.Value}\" restantes no estoque] ]");
                    return false;
                }
            
            }
            
            if(caR.Itens.Count <= 0)
            {
                Console.WriteLine("Impossível realizar a compra. Estoque insuficiente.");
                return false;
            }
        

        return true;
        }


         public void Comprar_Produtos()
        {

            if(!Conferir_Estoque()) return null;
        
            Console.WriteLine("=======================");
            foreach (var item in caR.Itens)
            {

            var autoSearch2 = est.Itens.FirstOrDefault(x => x.Key.Nome == item.Key.Nome);             
                
                for (var i = 0; i < item.Value; i++)
                {                        
                    est.Remover(item.Key);                              
                }   

            Console.WriteLine("O Produto foi adquirido com sucesso!");
                                
           }
        
        comprAtributos.Adicionar(caR.Itens);
        Console.WriteLine("=======================");

        }
       
    
    }

    public class Compra_Atributos
{
    private Dictionary<Produto, int> ite;
    
    private Cliente client;

    public Dictionary<Produto, int> Itens
    {
        get { return this.ite; }
    }

    public double Total
    {
        get
        {
            double somatorio = 0;
            // somatorio de valor total de cada item multiplicado pela quantidade de itens no carrinho
            foreach (KeyValuePair<Produto, int> parOrdenado in this.ite)
                somatorio += parOrdenado.Key.CalculaValorTotal() * parOrdenado.Value;

            return somatorio;
        }
    }

    

    public Compra_Atributos(Cliente cliente_)
    {
        this.ite = new Dictionary<Produto, int>();
        this.client = cliente_;
    }
    
    public void Adicionar(Produto item, int quantidade)
    {
        if (this.ite.ContainsKey(item))
            this.ite[item] = this.ite[item] + quantidade;
        else
            this.ite[item] = quantidade;
    }

    public void Adicionar(Produto item)
    {
        this.Adicionar(item, 1);
    }
    
    public void Adicionar(List<Produto> itens)
    {
        foreach (var item in itens)
        {
            this.Adicionar(item);
        }
    }
    
    public void Adicionar(Dictionary<Produto, int> itens)
    {
        foreach (KeyValuePair<Produto, int> parOrdenado in itens)
        {
            this.Adicionar(parOrdenado.Key, parOrdenado.Value);
        }
    }






    public void ImprimirAtributos()
    { 
        DateTime dateTime = DateTime.UtcNow.Date;
        Console.WriteLine("======== CARRINHO ========");
        Console.WriteLine("==========================");
        Console.WriteLine("Nome Cliente: \t{0}", client.Nome);     
        Console.WriteLine("CPF Cliente: \t{0}", client.Cpf);        
        Console.WriteLine("==========================");
        foreach (KeyValuePair<Produto, int> parOrdenado in this.ite)
        {
            parOrdenado.Key.Imprimir();
            Console.WriteLine("Data de compra:\t{0:0.00}", dateTime.ToString("dd/MM/yyyy"));
            Console.WriteLine("Quantidade: \tx{0} Unidades", parOrdenado.Value);         
            Console.WriteLine("==========================");
            Console.WriteLine("Subtotal:\tR$ {0:0.00}", parOrdenado.Value * parOrdenado.Key.CalculaValorTotal());
            Console.WriteLine("==========================");
        }
        Console.WriteLine("Valor Final :\tR$ {0:0.00}", this.Total);
        Console.WriteLine("==========================");
    }
}

public class Estoque
{
    private Dictionary<Produto, int> ite;

    public Dictionary<Produto, int> Itens 
    {
        get { return this.ite; }
    }


    public double Total
    {
        get
        {
            double somatorio = 0;
            // somatorio de valor total de cada item multiplicado pela quantidade de itens no Estoque
            foreach (KeyValuePair<Produto, int> parOrdenado in this.ite)
                somatorio += parOrdenado.Key.CalculaValorTotal() * parOrdenado.Value;

            return somatorio;
        }
    }

    public Estoque()
    {
        this.ite = new Dictionary<Produto, int>();
    }
    
    public void Adicionar(Produto item, int quantidade)
    {
        //Se já tiver um produto X ele vai aumentar a quantidade dele
        if (this.ite.ContainsKey(item))
            this.ite[item] = this.ite[item] + quantidade; 
        else              
            this.ite[item] = quantidade;
    }

    public void Adicionar(Produto item)
    {
        //Vai pegar o produto e a quantidade para adicionar ao carrinho
        this.Adicionar(item, 1);
    }
    
    public void Adicionar(List<Produto> itens)
    {   
        foreach (var item in itens)
        {    
            this.Adicionar(item);
        }
    }
   
    public void Adicionar(Dictionary<Produto, int> itens)
    {    
        foreach (KeyValuePair<Produto, int> parOrdenado in itens)
        {
            this.Adicionar(parOrdenado.Key, parOrdenado.Value);
        }
        
    }


    public void Remover(Produto Item)
    {
        var autoSearch2 = ite.FirstOrDefault(x => x.Key.Nome == Item.Nome);
    
        if( autoSearch2.Value == 1)
        {        
           ite.Remove(autoSearch2.Key);
           return;
        }
        else if(autoSearch2 >= 2)         
           ite[Item] -= 1;
     
    }
  


}

public class Fornecedor : IImprimivel
  {
      private string name;
      private string cnPj;

            public string Nome
            {
                get
                {
                return this.name;
                }
            }

            public string Cnpj
            {
                get
                {
                return this.cnPj;
                }
            }

            public Fornecedor(string nome, string cnpj)
            {
                this.name = nome;
                this.cnPj = cnpj;
            }
            
            public void Imprimir()
            {
                Console.WriteLine("Nome:\t{0}", this.Nome); 
                Console.WriteLine("CNPJ:\t{0}", this.Cnpj);
            }
   }

   public interface IImprimivel
    {
         void Imprimir();
    }

    public class Licensa : Produto
{
    
    protected string activationKey;

    public string ChaveAtivacao
    {
        get { return this.activationKey; }
    }

    public Licensa(string nome, double preco, string chaveAtivacao)
    {
        this.name = nome;
        this.price = preco;
        this.activationKey = chaveAtivacao;
    }

    public override double CalculaValorTotal()
    {
        return this.price;
    }

    public override void Imprimir()
    {
        Console.WriteLine("Software:\t{0}", this.Nome); 
        Console.WriteLine("Valor:\t\tR$ {0:0.00}", this.CalculaValorTotal());
    }
}

public abstract class Produto : IImprimivel
    {
        
        protected string name;
        protected double price;
        protected Fornecedor fornece;


        public Fornecedor Fornecedor
        {
            get {return this.fornece;}
        }


        public double Preco
        {
            get { return this.price;}
        }
        

        public string Nome
        {
            get { return this.name; }
        }
        

        public abstract double CalculaValorTotal();
        public abstract void Imprimir();
        
    }

    public class ProdutoFisico : Produto
    {

        private double freet;

        public double Frete
        {
            get { return this.freet; }
        }
        public ProdutoFisico(string nome, double preco, double frete, Fornecedor fornecedor)
        {
            this.name = nome;
            this.price = preco;
            this.forne = fornecedor;
            this.freet = frete;     
        }

        public override double CalculaValorTotal()
        {
            return this.freet + this.price;
        }
        public override void Imprimir()
        {
            Console.WriteLine("<========Fornecedor=======");
            Console.WriteLine("Nome:\t{0}", this.fornece.Nome);
            Console.WriteLine("CNPJ:\t{0}", this.fornece.Cnpj);
            Console.WriteLine("==========================");
            Console.WriteLine("Produto:\t{0}", this.Nome); 
            Console.WriteLine("Preço:\t\tR$ {0:0.00}", this.price);
            Console.WriteLine("Frete:\t\tR$ {0:0.00}", this.freet);
            Console.WriteLine("Valor:\t\tR$ {0:0.00}", this.CalculaValorTotal());
        }
    }

    public class Relatorio
    {
        private string title;
        private string desc;
        private List<IImprimivel> ite;

        public string Titulo
        {
            get
            {
                return this.title;
            }
        }
 
        public string Descricao
        {
            get
            {
                return this.desc;
            }
        }

        public Relatorio(string titulo, string descricao)
        {
            this.desc = descricao;
            this.title = titulo;
            this.ite = new List<IImprimivel>();
        }

        public void AdicionarItem(IImprimivel item)
        {
            this.ite.Add(item);
        }

        public void ImprimirRelatorio()
        {
            
            Console.WriteLine("\n======== RELATÓRIO ========");
            Console.WriteLine(this.title);
            Console.WriteLine("===========================");
            Console.WriteLine(this.desc);
            Console.WriteLine("========== ITENS ==========");
            foreach (var item in ite)
            {
                item.Imprimir(); 
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine("===========================");
        }
    }

    public static void Main(string[] args)
          {                 
                bool MostrarMenu = true;
                while (MostrarMenu)
                {
                    MostrarMenu = MenuPrincipal();
                }
          }

    }

}