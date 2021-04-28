using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace System.Windows
{
    static class Extensions
    {
        public static DependencyObject FindVisualRoot (this DependencyObject obj)
        {
            do
            {
                var parent = VisualTreeHelper.GetParent(obj);
                if (parent is null)
                {
                    return obj;
                }
                obj = parent;
            } while (true);
        }

        public static DependencyObject FindLogicalRoot ( this DependencyObject obj)
        {
            do
            {
                var parent = LogicalTreeHelper.GetParent(obj);
                if (parent is null)
                {
                    return obj;
                }
                obj = parent;
            } while (true);
        }

        public static T FindVisualParent<T>(this DependencyObject obj) where T : DependencyObject
        {
            if (obj is null) return null;
            var target = obj;
            do
            {
                target = VisualTreeHelper.GetParent(target);
            }
            while (target != null && !(target is T));
            return target as T;
        }

        public static T FindLogicalParent<T>(this DependencyObject obj) where T : DependencyObject
        {
            if (obj is null) return null;
            var target = obj;
            do
            {
                target = LogicalTreeHelper.GetParent(target);
            }
            while (target != null && !(target is T));
            return target as T;
        }

        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

               var queue = new Queue<DependencyObject>(new[] { parent });

                while (queue.Any())
                {
                    var reference = queue.Dequeue();
                    var count = VisualTreeHelper.GetChildrenCount(reference);

                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(reference, i);
                        if (child is T children)
                        {
                            yield return children;


                        }

                        queue.Enqueue(child);
                    }
                }
           
        }
    }
}
