#pragma once
<<<<<<< HEAD
#include "Game.h"
=======
#include "IGame.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class IGames
        {
        public:
            virtual ~IGames () = default;

<<<<<<< HEAD
            virtual IGame* new_game () = 0;
            virtual IGame* get_current_game () const = 0;
            virtual IGame* operator[] ( const size_t index ) const = 0;
            virtual size_t get_length () const = 0;
        };
=======
            virtual IGame_Ptr create_new_game () = 0;
            virtual IGame_Ptr get_current_game () const = 0;
            virtual IGame_Ptr get_game_at_index ( const size_t index ) const = 0;
            virtual size_t get_number_of_games () const = 0;
        };

        typedef std::shared_ptr<IGames> IGames_Ptr;
>>>>>>> Update from private repository
    };
};
