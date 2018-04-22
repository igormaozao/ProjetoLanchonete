using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Models {
    public class Enums {
        
        public enum ETipoPromocao {
            [Display(Name = "Nenhuma")]
            Nenhuma,
            [Display(Name = "Light")]
            Light,
            [Display(Name = "Muita Carne")]
            MuitaCarne,
            [Display(Name = "Muito Queijo")]
            MuitoQueijo
        }

        public enum ETipoAlimento {
            Carne,
            Queijo,
            Vegetal,
            Outros
        }
    }
}
