#pragma once

#include "Player.h"
#include <cstdint>
#include "TieBreakStatus.h"
<<<<<<< HEAD
=======
#include <memory>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class ITieBreak
        {
        public:
            virtual ~ITieBreak () = default;

<<<<<<< HEAD
            virtual void won_point ( Player player ) = 0;
            virtual uint8_t get_score ( Player player ) const = 0;
            virtual TieBreakStatus get_status () const = 0;
        };
=======
            virtual void won_point ( const Player player ) = 0;
            virtual uint8_t get_score ( const Player player ) const = 0;
            virtual TieBreakStatus get_status () const = 0;
        };

        typedef std::shared_ptr<ITieBreak> ITieBreak_Ptr;
>>>>>>> Update from private repository
    }
}
