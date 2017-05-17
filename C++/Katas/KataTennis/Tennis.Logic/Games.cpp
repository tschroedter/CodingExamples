<<<<<<< HEAD
#include <cassert>
#include "include/IGame.h"
#include "include/Game.h"
#include "include/Games.h"
#include "GameFactory.h"
=======
#include "include/IGame.h"
#include "include/Games.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        IGame* Games::new_game ()
        {
            m_current_game = m_factory->create();

            m_games.push_back ( m_current_game );

            return m_current_game;
        }

        IGame* Games::get_current_game () const
        {
            return m_current_game;
        }

        IGame* Games::operator[] ( const size_t index ) const
        {
            assert(index >= 0 && index < m_games.size());

            return ( m_games.at ( index ) );
        }

        size_t Games::get_length () const
        {
            return m_games.size();
=======
        IGame_Ptr Games::create_new_game ()
        {
            return new_item();
        }

        IGame_Ptr Games::get_current_game () const
        {
            return get_current_item();
        }

        IGame_Ptr Games::get_game_at_index ( const size_t index ) const
        {
            return ( *this ) [ index ];
        }

        size_t Games::get_number_of_games () const
        {
            return get_length();
>>>>>>> Update from private repository
        }
    };
};
