using System;

namespace Events.Data
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public int Guests { get; set; }
        public DateTime EventDate { get; set; }
        public bool Validated { get; set; } = false;
        public bool Premium { get; set; }

        //public bool IsEnable()
        //{
        //    return Quantity > 0 && ReleaseDate > DateTime.Now.AddYears(-1);
        //}
        //public bool IsForChild()
        //{
        //    return Type <= MovieType.Teen;
        //}
    }
}


//Cerrar evento

//Minimo de invitados
//Verificar fecha
//Meetup validado
//O sea premium 