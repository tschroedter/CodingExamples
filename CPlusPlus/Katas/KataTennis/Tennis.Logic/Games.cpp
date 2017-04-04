#include <cassert>
#include "include/IGame.h"
#include "include/Game.h"
#include "include/Games.h"
#include "GameFactory.h"

namespace Tennis
{
    namespace Logic
    {
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
        }
    };
};
