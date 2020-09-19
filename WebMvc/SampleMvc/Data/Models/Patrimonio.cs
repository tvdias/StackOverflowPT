﻿namespace SampleMvc.Data.Models
{
    public class Patrimonio
    {
        public int Id { get; set; }
        public int NumeroPatrimonio { get; set; }
        public string NumeroSerie { get; set; }
        public Local Local { get; set; }
        public int LocalId { get; set; } //Garantir que o Id deverá existir
        public string Coordenadas { get; set; }
        public string Usuario { get; set; }
        public string Observacao { get; set; }
        public bool Manutencao { get; set; }
    }
}