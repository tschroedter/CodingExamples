#pragma once
<<<<<<< HEAD
#pragma once
#include "Player.h"
#include "ISets.h"
#include "IMatchWonPointHandler.h"
=======
#include "Player.h"
#include "IMatchWonPointHandler.h"
#include "ISets.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class MatchWonPointHandler
<<<<<<< HEAD
            : public IMatchWonPointHandler
        {
        private:
            ISets* m_sets;

            bool is_tie_break_finsihed() const;
            void create_new_set_and_call_won_point(Player player) const;

        public:
            MatchWonPointHandler(ISets* sets)
                : m_sets(sets)
            {
            }

            ~MatchWonPointHandler()
            {
            }

            void won_point(const Player player) override;
        };
=======
                : public IMatchWonPointHandler
        {
        private:
            ISets_Ptr m_sets;

            bool is_tie_break_finsihed () const;
            void create_new_set_and_call_won_point ( Player player ) const;

        public:
            ~MatchWonPointHandler ()
            {
            }

            void initialize ( const ISets_Ptr sets ) override;
            void won_point ( const Player player ) override;
        };

        typedef std::shared_ptr<IMatchWonPointHandler> IMatchWonPointHandler_Ptr;
>>>>>>> Update from private repository
    };
};
