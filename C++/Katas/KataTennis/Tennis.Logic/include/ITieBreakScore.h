#pragma once

<<<<<<< HEAD
#pragma once
#include "Games.h"
=======
#include <string>
#include <memory>
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class ITieBreakScore
        {
        public:
            virtual ~ITieBreakScore () = default;

            virtual std::string to_string () const = 0;
            virtual void won_point () = 0;
            virtual uint8_t get_score () const = 0;
        };
<<<<<<< HEAD
=======

        typedef std::shared_ptr<ITieBreakScore> ITieBreakScore_Ptr;
>>>>>>> Update from private repository
    };
};
