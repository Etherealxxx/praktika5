//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace praktika2
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public int ID_account { get; set; }
        public int ID_friends { get; set; }
        public int ID_games { get; set; }
        public string nick { get; set; }
    
        public virtual friends friends { get; set; }
        public virtual games games {get; set; }
    }
}