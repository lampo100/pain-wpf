using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MoviesDatabase.ViewModel;

namespace MoviesDatabase.View
{
    public class WindowStateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CreateActorDataTemplate { get; set; }
        public DataTemplate CreateGenreDataTemplate { get; set; }
        public DataTemplate CreateMovieDataTemplate { get; set; }
        public DataTemplate EditActorDataTemplate { get; set; }
        public DataTemplate EditGenreDataTemplate { get; set; }
        public DataTemplate EditMovieDataTemplate { get; set; }
        public DataTemplate SelectedActorDataTemplate { get; set; }
        public DataTemplate SelectedGenreDataTemplate { get; set; }
        public DataTemplate SelectedMovieDataTemplate { get; set; }
        public DataTemplate DefaultDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var mapping = new Dictionary<Type, DataTemplate>
            {
                { typeof(CreateActorViewModel), CreateActorDataTemplate },
                { typeof(CreateGenreViewModel), CreateGenreDataTemplate },
                { typeof(CreateMovieViewModel), CreateMovieDataTemplate },
                { typeof(EditActorViewModel), EditActorDataTemplate },
                { typeof(EditGenreViewModel), EditGenreDataTemplate},
                { typeof(EditMovieViewModel), EditMovieDataTemplate},
                { typeof(SelectedActorViewModel), SelectedActorDataTemplate },
                { typeof(SelectedGenreViewModel), SelectedGenreDataTemplate },
                { typeof(SelectedMovieViewModel), SelectedMovieDataTemplate }
            };

            if (item != null && mapping.TryGetValue(item.GetType(), out var result))
                return result;
            else
                return DefaultDataTemplate;
        }
    }
}
