import { toast } from "sonner"

type ApiError = {
    title?: string
    detail?: string
    status?: number
    errors?: string[]
}

export function notifyError(err: any, fallback = "Unexpected error") {
    const data: ApiError | undefined = err?.response?.data

    if (data?.errors?.length) {
        toast.error(data.title ?? "Validation error", {
            description: data.errors.join(" • "),
            duration: 6000
        })
        return
    }

    if (data?.title || data?.detail) {
        toast.error(data.title ?? "Error", {
            description: data.detail ?? fallback,
            duration: 6000
        })
        return
    }

    toast.error("Unexpected error", {
        description: fallback,
        duration: 6000
    })
}
