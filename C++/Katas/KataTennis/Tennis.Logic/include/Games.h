#pragma once
#include "IGames.h"
#include "../GameFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class Games
                : public IGames
        {
        private:
            std::unique_ptr<GameFactory> m_factory;
            IGame* m_current_game = nullptr;
            std::vector<IGame*> m_games;
        public:
            Games ( std::unique_ptr<GameFactory> factory )
                : m_factory ( std::move ( factory ) )
            {
            }

            ~Games ()
            {
                for ( IGame* game : m_games )
                {
                    m_factory->release ( game );
                }

                m_games.clear();
            }

            IGame* new_game () override;

            IGame* get_current_game () const override;

            IGame* operator[] ( const size_t index ) const override;

            size_t get_length () const override;
        };
    };
};
