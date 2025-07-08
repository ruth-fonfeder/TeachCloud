// import React from "react";

// interface ModalProps {
//   isOpen: boolean;
//   onClose: () => void;
//   title?: string;
//   children: React.ReactNode;
// }

// const Modal = ({ isOpen, onClose, title, children }: ModalProps) => {
//   if (!isOpen) return null;

//   return (
//     <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-40">
//       <div className="bg-white rounded-xl shadow-lg p-6 w-full max-w-xl">
//         <div className="flex justify-between items-center mb-4">
//           <h3 className="text-xl font-semibold">{title}</h3>
//           <button onClick={onClose} className="text-gray-500 hover:text-black text-lg">×</button>
//         </div>
//         <div>{children}</div>
//       </div>
//     </div>
//   );
// };

// export default Modal;

// import type React from "react"

// interface ModalProps {
//   isOpen: boolean
//   onClose: () => void
//   title?: string
//   children: React.ReactNode
// }

// const Modal = ({ isOpen, onClose, title, children }: ModalProps) => {
//   if (!isOpen) return null

//   return (
//     <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-40">
//       <div className="bg-white rounded-xl shadow-lg p-6 w-full max-w-xl">
//         <div className="flex justify-between items-center mb-4">
//           <h3 className="text-xl font-semibold">{title}</h3>
//           <button onClick={onClose} className="text-gray-500 hover:text-black text-lg">
//             ×
//           </button>
//         </div>
//         <div>{children}</div>
//       </div>
//     </div>
//   )
// }

// export default Modal

// import React from "react";

// type ModalProps = {
//   isOpen: boolean;
//   onClose: () => void;
//   title?: string;
//   children: React.ReactNode;
// };

// const Modal = ({ isOpen, onClose, title, children }: ModalProps) => {
//   if (!isOpen) return null;

//   return (
//     <div >
//       <div  className="container">
//         <button
//           onClick={onClose}
//           // className="absolute top-2 left-2 text-gray-600 hover:text-black text-xl"
//         >
//           ✕
//         </button>
//         {title && <h2 className="">{title}</h2>}
//         {children}
//       </div>
//     </div>
//   );
// };

// export default Modal;



// 


import React from "react";

type ModalProps = {
  isOpen: boolean;
  onClose: () => void;
  title?: string;
  children: React.ReactNode;
};


const Modal = ({ isOpen, onClose, title, children }: ModalProps) => {
  if (!isOpen) return null;

  return (
    // <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
    //   <div className="bg-white rounded-lg shadow-lg p-6 w-full max-w-xl relative">
    //     <button
    //       onClick={onClose}
    //       className="absolute top-2 right-2 text-gray-600 hover:text-black text-xl"
    //     >
    //       ✕
    //     </button>
    //     {title && <h2 className="text-lg font-bold mb-4">{title}</h2>}
    //     {children}
    //   </div>
    // </div>
    <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-[9999]">
      <div className="bg-white rounded-lg shadow-lg p-6 w-full max-w-xl relative">
        <button className="absolute top-2 right-2"
          onClick={onClose}
        >✕</button>
         {title && <h2 className="text-lg font-bold mb-4">{title}</h2>}
        {children}
      </div>
    </div>

  );
};

export default Modal;