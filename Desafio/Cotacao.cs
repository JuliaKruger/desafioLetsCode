using System;

namespace Desafio
{
    public class Cotacao
    {
         public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }

    public class Moeda 
    {
        public Cotacao BRLUSD { get; set;}
        public Cotacao BRLRUB {get; set;}
    }
}