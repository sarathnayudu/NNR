﻿using NNR.Context.EntityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace TeleMed.Context.Infrastructure
{
    public class ContextManager
    {
        #region Private Members

        // accessed via lock(_threadObjectContexts), only required for multi threaded non web applications
        private static readonly Hashtable _threadObjectContexts = new Hashtable();

        #endregion

        public static IDbSet<T> GetObjectSet<T>(T entity, string contextKey)
            where T : class
        {
            return GetObjectContext(contextKey).Set<T>();
        }

        public static DbContext GetObjectContext(string contextKey)
        {
            DbContext objectContext = GetCurrentObjectContext(contextKey);
            if (objectContext == null) // create and store the object context
            {
                objectContext = new TrnzDBEntities();
                StoreCurrentObjectContext(objectContext, contextKey);
            }
            return objectContext;
        }

        public static object GetRepositoryContext(string contextKey)
        {
            return GetObjectContext(contextKey);
        }

        public static void SetRepositoryContext(object repositoryContext, string contextKey)
        {
            if (repositoryContext == null)
            {
                RemoveCurrentObjectContext(contextKey);
            }
            else if (repositoryContext is ObjectContext)
            {
                StoreCurrentObjectContext((DbContext)repositoryContext, contextKey);
            }
        }


        #region Object Context Lifecycle Management

        /// <summary>
        /// gets the current object context 		
        /// </summary>
        private static DbContext GetCurrentObjectContext(string contextKey)
        {
            DbContext objectContext = null;
            if (HttpContext.Current == null)
                objectContext = GetCurrentThreadObjectContext(contextKey);
            else
                objectContext = GetCurrentHttpContextObjectContext(contextKey);
            return objectContext;
        }

        /// <summary>
        /// sets the current session 		
        /// </summary>
        private static void StoreCurrentObjectContext(DbContext objectContext, string contextKey)
        {
            if (HttpContext.Current == null)
                StoreCurrentThreadObjectContext(objectContext, contextKey);
            else
                StoreCurrentHttpContextObjectContext(objectContext, contextKey);
        }

        /// <summary>
        /// remove current object context 		
        /// </summary>
        private static void RemoveCurrentObjectContext(string contextKey)
        {
            if (HttpContext.Current == null)
                RemoveCurrentThreadObjectContext(contextKey);
            else
                RemoveCurrentHttpContextObjectContext(contextKey);
        }

        #region private methods - HttpContext related

        /// <summary>
        /// gets the object context for the current thread
        /// </summary>
        private static DbContext GetCurrentHttpContextObjectContext(string contextKey)
        {
            DbContext objectContext = null;
            if (HttpContext.Current.Items.Contains(contextKey))
                objectContext = (DbContext)HttpContext.Current.Items[contextKey];
            return objectContext;
        }

        private static void StoreCurrentHttpContextObjectContext(DbContext objectContext, string contextKey)
        {
            if (HttpContext.Current.Items.Contains(contextKey))
                HttpContext.Current.Items[contextKey] = objectContext;
            else
                HttpContext.Current.Items.Add(contextKey, objectContext);
        }

        /// <summary>
        /// remove the session for the currennt HttpContext
        /// </summary>
        private static void RemoveCurrentHttpContextObjectContext(string contextKey)
        {
            DbContext objectContext = GetCurrentHttpContextObjectContext(contextKey);
            if (objectContext != null)
            {
                HttpContext.Current.Items.Remove(contextKey);
                objectContext.Dispose();
            }
        }

        #endregion

        #endregion

        #region private methods - ThreadContext related

        /// <summary>
        /// gets the session for the current thread
        /// </summary>
        private static DbContext GetCurrentThreadObjectContext(string contextKey)
        {
            DbContext objectContext = null;
            Thread threadCurrent = Thread.CurrentThread;
            if (threadCurrent.Name == null)
                threadCurrent.Name = contextKey;
            else
            {
                object threadObjectContext = null;
                lock (_threadObjectContexts.SyncRoot)
                {
                    threadObjectContext = _threadObjectContexts[contextKey];
                }
                if (threadObjectContext != null)
                    objectContext = (DbContext)threadObjectContext;
            }
            return objectContext;
        }

        private static void StoreCurrentThreadObjectContext(DbContext objectContext, string contextKey)
        {
            lock (_threadObjectContexts.SyncRoot)
            {
                if (_threadObjectContexts.Contains(contextKey))
                    _threadObjectContexts[contextKey] = objectContext;
                else
                    _threadObjectContexts.Add(contextKey, objectContext);
            }
        }

        private static void RemoveCurrentThreadObjectContext(string contextKey)
        {
            lock (_threadObjectContexts.SyncRoot)
            {
                if (_threadObjectContexts.Contains(contextKey))
                {
                    ObjectContext objectContext = (ObjectContext)_threadObjectContexts[contextKey];
                    if (objectContext != null)
                    {
                        objectContext.Dispose();
                    }
                    _threadObjectContexts.Remove(contextKey);
                }
            }
        }

        #endregion
    }
}
