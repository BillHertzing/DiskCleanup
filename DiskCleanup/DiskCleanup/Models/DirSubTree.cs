using System;
using System.Collections.Generic;
using System.IO;

namespace DiskCleanup.Models
{
    // Data Types
    /// <summary>
    /// A class that encapsulates the sealed DirectoryInfo class.
    /// </summary>
    public class DirSubTree
    {
        #region Data
        List<DirSubTree> _children = new List<DirSubTree>();
        public IList<DirSubTree> Children
        {
            get { return _children; }
        }
        public DirectoryInfo DirInfo { get; set; }
        #endregion // Data

        #region Constructors
        public DirSubTree(String path)
        {
            try
            {
                DirInfo = new DirectoryInfo(path);
                foreach (var cdir in DirInfo.GetDirectories())
                {
                    _children.Add(new DirSubTree(cdir));
                }
            }
            catch (DirectoryNotFoundException NFEx)
            {
                Console.WriteLine(NFEx.Message);
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }

        public DirSubTree(DirectoryInfo dir)
        {
            try
            {
                DirInfo = dir;
                foreach (var cdir in DirInfo.GetDirectories())
                {
                    _children.Add(new DirSubTree(cdir));
                }
            }
            catch (DirectoryNotFoundException NFEx)
            {
                Console.WriteLine(NFEx.Message);
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }
        #endregion // Constructors
    }
}
