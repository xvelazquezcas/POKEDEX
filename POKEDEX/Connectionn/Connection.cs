using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
//este es el buenoo

namespace POKEDEX.Connectionn
{
    public class Connection
    {
        public static FirebaseClient firebase = new FirebaseClient("https://pokedex-2544d-default-rtdb.firebaseio.com/");
    }
}
