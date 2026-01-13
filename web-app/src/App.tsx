import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom"
import { AppLayout } from "./layouts/AppLayout"
import { Dashboard } from "./pages/Dashboard"

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<AppLayout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}
