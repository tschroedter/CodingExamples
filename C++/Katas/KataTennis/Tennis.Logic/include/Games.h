#pragma once
<<<<<<< HEAD
#include "IGames.h"
#include "../GameFactory.h"
=======
#include "Container.h"
#include "IGames.h"
#include <Hypodermic/FactoryWrapper.h>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class Games
<<<<<<< HEAD
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
=======
                : public Container<IGame>
                  , public IGames
        {
        public:
            Games (
                const Hypodermic::FactoryWrapper<IGame>& factory_wrapper )
                : Container<IGame> ( factory_wrapper )
            {
            }

            IGame_Ptr create_new_game () override;
            IGame_Ptr get_current_game () const override;
            IGame_Ptr get_game_at_index ( const size_t index ) const override;
            size_t get_number_of_games () const override;
>>>>>>> Update from private repository
        };
    };
};
