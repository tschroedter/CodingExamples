#pragma once
#include "Game.h"

namespace Tennis
{
    namespace Logic
    {
        class IGames
        {
        public:
            virtual ~IGames () = default;

            virtual IGame* new_game () = 0;
            virtual IGame* get_current_game () const = 0;
            virtual IGame* operator[] ( const size_t index ) const = 0;
            virtual size_t get_length () const = 0;
        };
    };
};
