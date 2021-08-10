using AdminApp.Components;
using AdminApp.Services.Interfaces;
using AdminApp.Shared;
using Examination.Dtos.Categories;
using Examination.Dtos.SeedWork;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Pages.Applications.Category
{
    public partial class List
    {
        [Inject] private ICategoryService _categoryService { set; get; }
        [Inject] private IDialogService _dialogService { set; get; }
        [Inject] private NavigationManager _navigationManager { set; get; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private string DeleteId { set; get; }
        private List<CategoryDto> Elements;
        public MetaData MetaData { get; set; } = new MetaData();

        private CategorySearch TaskListSearch = new CategorySearch();

        [CascadingParameter]
        private Error Error { set; get; }

        protected override async Task OnInitializedAsync()
        {
            await GetTasks();
        }

        public async Task SearchTask(CategorySearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
        }

        public async Task OnDeleteTask(string deleteId)
        {
            DeleteId = deleteId;
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to delete these records? This process cannot be undone.");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

           var dialog = _dialogService.Show<ConfirmationDialog>("Delete", parameters, options);
           var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await _categoryService.Delete(DeleteId);
                await GetTasks();
            }
        }

        private async Task GetTasks()
        {
            try
            {
                var pagingResponse = await _categoryService.GetListPaging(TaskListSearch);
                Elements = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }

        }

        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }

        private void NavigateToEdit(string id)
        {
            _navigationManager.NavigateTo($"/pages/applications/categories/{id}");
        }
    }
}
