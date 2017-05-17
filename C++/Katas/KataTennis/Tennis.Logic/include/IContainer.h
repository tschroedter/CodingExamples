#pragma once
namespace Tennis
{
    namespace Logic
    {
        template <class T>
        class IContainer
        {
        public:
            virtual ~IContainer () = default;

            virtual std::shared_ptr<T> new_item () = 0;
            virtual std::shared_ptr<T> get_current_item () const = 0;
            virtual std::shared_ptr<T> operator[] ( const size_t index ) const = 0;
            virtual size_t get_length () const = 0;
        };
    };
};
