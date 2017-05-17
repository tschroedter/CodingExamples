#pragma once
#include "Container.h"
#include "IGames.h"
#include <Hypodermic/FactoryWrapper.h>

namespace Tennis
{
    namespace Logic
    {
        class Games
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
        };
    };
};
