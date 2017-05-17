#include "Sets.h"
#include <cassert>

namespace Tennis
{
    namespace Logic
    {
        // todo create generic/template, see Games
<<<<<<< HEAD
        ISet* Sets::new_set () // todo testing
        {
            m_current_set = m_factory->create();  // todo odd should create ISet*
=======
        ISet* Sets::new_set ()
        {
            m_current_set = m_factory->create();
>>>>>>> Update from private repository

            m_sets.push_back ( m_current_set );

            return m_current_set;
        }

<<<<<<< HEAD
        ISet* Sets::get_current_set () const // todo testing
=======
        ISet* Sets::get_current_set () const
>>>>>>> Update from private repository
        {
            return m_current_set;
        }

<<<<<<< HEAD
        ISet* Sets::operator[] ( const size_t index ) const // todo testing
=======
        ISet* Sets::operator[] ( const size_t index ) const
>>>>>>> Update from private repository
        {
            assert(index >= 0 && index < m_sets.size());

            return ( m_sets.at ( index ) );
        }

<<<<<<< HEAD
        size_t Sets::get_length () const // todo testing
=======
        size_t Sets::get_length () const
>>>>>>> Update from private repository
        {
            return m_sets.size();
        }
    };
};
