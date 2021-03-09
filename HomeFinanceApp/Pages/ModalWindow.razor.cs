using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace HomeFinanceApp.Pages
{
    public class ModalWindowPage : ComponentBase
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public void ClosePopup()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
