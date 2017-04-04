#pragma once
#include "ISets.h"
#include <memory>
#include "vector"
#include "SetFactory.h"
#include "ISet.h"

namespace Tennis
{
    namespace Logic
    {
        class Sets // todo testing
                : public ISets
        {
        private:
            std::unique_ptr<ISetFactory> m_factory;
            ISet* m_current_set;
            std::vector<ISet*> m_sets;

        public:
            Sets ( std::unique_ptr<ISetFactory> factory )
                : m_factory ( std::move ( factory ) )
            {
            }

            ~Sets ()
            {
                for (ISet* set : m_sets)
                {
                    m_factory->release(set);
                }

                m_sets.clear();
            }

            ISet* new_set () override;
            ISet* get_current_set () const override;
            ISet* operator[] ( const size_t index ) const override;
            size_t get_length () const override;
        };
    };
};
