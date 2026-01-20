using System.Collections.Generic;
using System.Linq;

namespace Sufficit
{
    /// <summary>
    /// Extension methods for RemoteServer filtering and manipulation
    /// </summary>
    public static class RemoteServerExtensions
    {
        /// <summary>
        /// Filters servers by tag
        /// </summary>
        /// <param name="servers">Collection of servers to filter</param>
        /// <param name="tag">Tag to search for (case-insensitive)</param>
        /// <returns>Servers that contain the specified tag</returns>
        public static IEnumerable<RemoteServer> WithTag(this IEnumerable<RemoteServer> servers, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return servers;

            var normalizedTag = tag.Trim().ToLowerInvariant();
            return servers.Where(s => s.Tags != null && s.Tags.Any(t => t.Trim().ToLowerInvariant() == normalizedTag));
        }

        /// <summary>
        /// Filters servers by multiple tags (OR logic - server must have at least one of the tags)
        /// </summary>
        /// <param name="servers">Collection of servers to filter</param>
        /// <param name="tags">Tags to search for</param>
        /// <returns>Servers that contain at least one of the specified tags</returns>
        public static IEnumerable<RemoteServer> WithAnyTag(this IEnumerable<RemoteServer> servers, params string[] tags)
        {
            if (tags == null || tags.Length == 0)
                return servers;

            var normalizedTags = new HashSet<string>(tags.Select(t => t.Trim().ToLowerInvariant()));
            return servers.Where(s => s.Tags != null && s.Tags.Any(t => normalizedTags.Contains(t.Trim().ToLowerInvariant())));
        }

        /// <summary>
        /// Filters servers by multiple tags (AND logic - server must have all tags)
        /// </summary>
        /// <param name="servers">Collection of servers to filter</param>
        /// <param name="tags">Tags to search for</param>
        /// <returns>Servers that contain all specified tags</returns>
        public static IEnumerable<RemoteServer> WithAllTags(this IEnumerable<RemoteServer> servers, params string[] tags)
        {
            if (tags == null || tags.Length == 0)
                return servers;

            var normalizedTags = new HashSet<string>(tags.Select(t => t.Trim().ToLowerInvariant()));
            return servers.Where(s => 
                s.Tags != null && 
                normalizedTags.All(tag => s.Tags.Any(t => t.Trim().ToLowerInvariant() == tag))
            );
        }
    }
}
